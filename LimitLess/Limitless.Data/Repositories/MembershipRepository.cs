using Limitless.Data.Infrastructure;
using Limitless.Model;

namespace Limitless.Data.Repositories
{
    public class MembershipRepository : RepositoryBase<Membership>, IMembershipRepository
    {
        public MembershipRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }



    }

    public interface IMembershipRepository : IRepository<Membership>
    {
    }
}
