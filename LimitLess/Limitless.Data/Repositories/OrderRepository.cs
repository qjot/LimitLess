using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Data.Infrastructure;
using Limitless.Model;

namespace Limitless.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

     

    }

    public interface IOrderRepository : IRepository<Order>
    {
    }
}
