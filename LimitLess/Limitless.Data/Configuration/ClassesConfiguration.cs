using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Model;
using System.Data.Entity.ModelConfiguration;

namespace Limitless.Data.Configuration
{
    public class ClassesConfiguration : EntityTypeConfiguration<Classes>
    {
        public ClassesConfiguration()
        {
            ToTable("Classes");
            Property(g => g.classesId).IsRequired();
            Property(g => g.name).IsRequired().HasMaxLength(50);
            Property(g => g.description).IsRequired().HasMaxLength(500);

        }
    }
}
