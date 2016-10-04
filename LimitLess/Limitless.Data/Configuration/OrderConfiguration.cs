using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Model;

namespace Limitless.Data.Configuration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Orders");
            Property(o => o.orderId).IsRequired();
            Property(o => o.address).IsRequired();
            Property(o => o.city).IsRequired();
            Property(o => o.country).IsRequired();
            Property(o => o.email).IsRequired();
            Property(o => o.firstName).IsRequired().HasMaxLength(30);
            Property(o => o.lastName).IsRequired().HasMaxLength(30); ;
            Property(o => o.postalCode).IsRequired();
            Property(o => o.total).IsRequired();
            Property(o => o.username).IsRequired();

        }
    }
}
