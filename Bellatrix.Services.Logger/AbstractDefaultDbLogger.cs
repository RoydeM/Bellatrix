using Bellatrix.Core;

namespace Bellatrix.Services.Logger
{
    public abstract class AbstractDefaultDbLogger
    {
        protected char GetLevel(LogLevel level)
        {
            char ch;
            switch (level)
            {
                case LogLevel.Success:
                    ch = 'S';
                    break;
                case LogLevel.Warning:
                    ch = 'W';
                    break;
                case LogLevel.Error:
                    ch = 'E';
                    break;
                default:
                    ch = ' ';
                    break;
            }
            return ch;
        }
    }
}