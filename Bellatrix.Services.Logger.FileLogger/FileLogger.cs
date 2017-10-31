using Bellatrix.Core;
using System;
using System.Configuration;
using System.IO;

namespace Bellatrix.Services.Logger.FileLogger
{
    public class FileLogger : AbstractDefaultTextLogger, ILogger
    {
        public void Log(LogLevel level, string message)
        {
            string path = ConfigurationManager.AppSettings["FileLoggerPath"];
            using (StreamWriter stream = File.AppendText(path))
            {
                stream.WriteLine("[{0}]{1}:{2}", DateTime.Now.ToLongTimeString(), GetLevel(level), message);
                stream.Close();
            }
        }
    }
}