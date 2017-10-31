namespace Bellatrix.Core
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }
}