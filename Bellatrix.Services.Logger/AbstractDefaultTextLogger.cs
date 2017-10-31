using Bellatrix.Core;

namespace Bellatrix.Services.Logger
{
    public abstract class AbstractDefaultTextLogger 
    {
        protected string GetLevel(LogLevel level)
        {
            string label;
            switch (level)
            {
                case LogLevel.Success:
                    label = "[OK   ]";
                    break;
                case LogLevel.Warning:
                    label = "[WARN ]";
                    break;
                case LogLevel.Error:
                    label = "[ERROR]";
                    break;
                default:
                    label = "[NULL ]";
                    break;
            }
            return label;
        }
    }
}