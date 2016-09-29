using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory DbFactory;
        private LimitlessEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
        }

        public LimitlessEntities DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init());  }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
