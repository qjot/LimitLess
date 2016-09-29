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

        public Hall GetHallByName(string hallName)
        {
            var hall = this.DbContext.halls.FirstOrDefault(x => x.name == hallName);
            return hall;
        }

    }

    public interface IHallRepository : IRepository<Hall>
    {
       Hall GetHallByName(string hallName);
    }
}
