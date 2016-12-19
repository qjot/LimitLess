using Limitless.Model;
using System.Data.Entity.ModelConfiguration;

namespace Limitless.Data.Cofiguration
{
    class LogConfiguration : EntityTypeConfiguration<Logs>
    {
        public LogConfiguration()
        {
            ToTable("Logs");
            Property(g => g.logId).IsRequired();

        }
    }
}
