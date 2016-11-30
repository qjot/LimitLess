using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Model;

namespace Limitless.Data.Cofiguration
{
    class MembershipConfiguration : EntityTypeConfiguration<Membership>
    {
        public MembershipConfiguration()
        {
            ToTable("Membership");
            Property(g => g.membershipId).IsRequired();
            Property(g => g.price).IsRequired();
            Property(g => g.title).IsRequired().HasMaxLength(500);

        }
    }
}
