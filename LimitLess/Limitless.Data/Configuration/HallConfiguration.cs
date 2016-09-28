using System.Data.Entity.ModelConfiguration;
using Limitless.Model;

namespace Limitless.Data.Configuration
{
    public class HallConfiguration : EntityTypeConfiguration<Hall>
    {
        public HallConfiguration()
        {
            ToTable("Hall");
            Property(g => g.hallId).IsRequired();
            Property(g => g.name).IsRequired().HasMaxLength(50);
            Property(g => g.maxCapacity).IsRequired();
        }
    }
}
