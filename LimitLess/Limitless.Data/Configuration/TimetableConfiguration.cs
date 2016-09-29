using System.Data.Entity.ModelConfiguration;
using Limitless.Model;

namespace Limitless.Data.Configuration
{
    public class TimetableConfiguration : EntityTypeConfiguration<Timetable>
    {
        public TimetableConfiguration()
        {
            ToTable("Timetables");
            Property(g => g.capacity).IsRequired();
            Property(g => g.timetableID).IsRequired();
            Property(g => g.date.Value).IsRequired();
        }
    }
}
