using Limitless.Data.Infrastructure;
using Limitless.Model;

namespace Limitless.Data.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
        public override void Update(Event entity)
        {
            base.Update(entity);
        }
    }

    public interface IEventRepository : IRepository<Event>
    {
    }
}
