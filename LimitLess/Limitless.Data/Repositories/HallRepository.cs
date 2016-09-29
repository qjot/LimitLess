using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Data.Infrastructure;
using Limitless.Model;

namespace Limitless.Data.Repositories
{
    public class HallRepository : RepositoryBase<Hall>, IHallRepository
    {
        public HallRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

    }

    public interface IHallRepository : IRepository<Hall>
    {
        
    }
}
