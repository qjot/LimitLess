using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Data.Infrastructure;
using Limitless.Model;

namespace Limitless.Data.Repositories
{
    public class TimetableRepository : RepositoryBase<Timetable>, ITimetableRepository
    {
        public TimetableRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }


    }

    internal interface ITimetableRepository
    {
    }
}
