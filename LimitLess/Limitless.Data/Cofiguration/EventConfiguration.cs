using System.Data.Entity.ModelConfiguration;
using Limitless.Model;

namespace Limitless.Data.Configuration
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            ToTable("Events");
            Property(g => g.capacity).IsRequired();
            Property(g => g.eventId).IsRequired();
           // Property(g => g.date.Value).IsRequired();
        }
    }
}
