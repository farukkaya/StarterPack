using Serilog.Core;

namespace Core.CrossCuttingConcerns.Logging.SeriLog.Concrete
{
    public abstract class LoggingConfiguration
    {
        protected abstract Logger GetLogger();

        public Logger InstanceLogger()
        {
            return default(Logger);
        }

    }
}
