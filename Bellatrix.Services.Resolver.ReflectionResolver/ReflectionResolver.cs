using Bellatrix.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bellatrix.Services.Resolver.ReflectionResolver
{
    public class ReflectionResolver : IResolver
    {
        private const string filter = "*.dll";

        private string path;
        private FileSystemWatcher watcher;
        private Dictionary<string, List<Type>> cache;

        public ReflectionResolver()
        {
            path = ConfigurationManager.AppSettings["ReflectionResolverPath"];
            cache = new Dictionary<string, List<Type>>();
            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.Filter = filter;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += Watcher_Changed;
            watcher.EnableRaisingEvents = true;
        }
        
        private bool BuildCacheFor(string key)
        {
            string[] files = Directory.GetFiles(path, filter);
            bool success = false;
            foreach (string file in files)
            {
                Assembly assembly = Assembly.LoadFrom(file);
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Any(t => t.FullName == key))
                    {
                        if (!cache.ContainsKey(key))
                        {
                            cache.Add(key, new List<Type>());
                        }
                        cache[key].Add(type);
                        if (!success)
                        {
                            success = true;
                        }
                    }
                }
            }
            return success;
        }

        private void ClearCache()
        {
            cache.Clear();
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            ClearCache();
        }

        public object Resolve(Type type)
        {
            string key = type.FullName;
            if (!cache.ContainsKey(key))
            {
                if (!BuildCacheFor(key))
                {
                    Console.WriteLine("Cannot resolve type: " + key);
                    return null;
                }
            }
            return CreateInstance(cache.Single(p => p.Key == key).Value.First());
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public ICollection<T> ResolveAll<T>()
        {
            string key = typeof(T).FullName;
            if (!cache.ContainsKey(key))
            {
                if (!BuildCacheFor(key))
                {
                    Console.WriteLine("Cannot resolve type: " + key);
                    return null;
                }
            }
            return cache.Single(p => p.Key == key).Value.Select(p => (T)CreateInstance(p)).ToList();
        }

        private object CreateInstance(Type type)
        {
            ConstructorInfo consInfo = type.GetConstructors().First();
            if (consInfo.GetParameters().Count() == 0)
            {
                return consInfo.Invoke(Type.EmptyTypes);
            }
            else
            {
                var para = consInfo.GetParameters();
                List<object> instances = new List<object>(para.Count());
                foreach (var p in para)
                {
                    instances.Add(Resolve(p.ParameterType));
                }
                return consInfo.Invoke(instances.ToArray());
            }
        }
    }
}