using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Data.Infrastructure
{
    public class DbFactory :  Disposable, IDbFactory
    {
        LimitlessEntities dbContext;

        public LimitlessEntities Init()
        {
            return dbContext ?? (dbContext = new LimitlessEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
