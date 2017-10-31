using Bellatrix.Core;

namespace Bellatrix.Services.Logger
{
    public class Logger
    {
        public void Log(LogLevel level, string message)
        {
            var implementations = BellatrixApplication.Instance.Resolver.ResolveAll<ILogger>();
            if (implementations != null)
            { 
                foreach (ILogger logger in implementations)
                {
                    logger.Log(level, message);
                }
            }
        }
    }
}