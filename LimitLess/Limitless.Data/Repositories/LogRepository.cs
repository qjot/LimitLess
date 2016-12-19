using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Limitless.Data.Infrastructure;
using Limitless.Model;

namespace Limitless.Data.Repositories
{
    public class LogsRepository : RepositoryBase<Logs>, ILogsRepository
    {
        public LogsRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Logs GetLogById(int id)
        {
            var log = this.DbContext.logs.FirstOrDefault(c => c.logId == id);
            return log;
        }

    }

    public interface ILogsRepository : IRepository<Logs>
    {
        Logs GetLogById(int id);
    }
}