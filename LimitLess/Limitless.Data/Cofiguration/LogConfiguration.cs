using Limitless.Model;
using System.Data.Entity.ModelConfiguration;

namespace Limitless.Data.Cofiguration
{
    class LogConfiguration : EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
        {
            ToTable("Logs");
            Property(g => g.idLog).IsRequired();

        }
    }
}
