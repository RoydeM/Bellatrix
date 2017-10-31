using Bellatrix.Core;
using System;
using System.Data;

namespace Bellatrix.Services.Logger.DbLogger
{
    public class DbLogger : AbstractDefaultDbLogger, ILogger
    {
        private IRepository repository;

        public DbLogger(IRepository repository)
        {
            this.repository = repository;
        }

        public void Log(LogLevel level, string message)
        {
            IDbDataParameter p1 = repository.CreateParameter("level", GetLevel(level));
            IDbDataParameter p2 = repository.CreateParameter("message", message);
            IDbDataParameter p3 = repository.CreateParameter("creationDate", DateTime.Now);
            repository.Execute("insert into LogEntry(Level,Message,CreatedOn) values(@level,@message,@creationDate)", p1, p2, p3);
        }
    }
}