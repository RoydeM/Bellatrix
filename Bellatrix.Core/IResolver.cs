using System;
using System.Collections.Generic;

namespace Bellatrix.Core
{
    public interface IResolver
    {
        object Resolve(Type type);
        T Resolve<T>();
        ICollection<T> ResolveAll<T>();
    }
}