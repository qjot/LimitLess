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
    public class LogsRepository : RepositoryBase<Log>, ILogsRepository
    {
        public LogsRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Log GetLogById(int id)
        {
            var log = this.DbContext.logs.FirstOrDefault(c => c.idLog == id);
            return log;
        }

    }

    public interface ILogsRepository : IRepository<Log>
    {
        Log GetLogById(int id);
    }
}