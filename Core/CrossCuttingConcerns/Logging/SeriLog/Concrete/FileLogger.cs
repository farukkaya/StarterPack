using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.SeriLog.Concrete
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("FileLogger")
        {
        }
    }
}
