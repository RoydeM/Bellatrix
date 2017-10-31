using System;
using Bellatrix.Core;

namespace Bellatrix.Services.Logger.ConsoleLogger
{
    public class ConsoleLogger : AbstractDefaultTextLogger, ILogger
    {
        public void Log(LogLevel level, string message)
        {
            Console.WriteLine("[{0}]{1}:{2}", DateTime.Now.ToLongTimeString(), GetLevel(level), message);
        }
    }
}