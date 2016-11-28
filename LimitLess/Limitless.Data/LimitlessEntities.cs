using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Limitless.Data.Configuration;
using Limitless.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
namespace Limitless.Data
{
    public class LimitlessEntities : DbContext
    {
        private static string connectionString =
            @"Data Source=DESKTOP-K4473GC\SQLEXPRESS;Initial Catalog=LimitlessEntities;Integrated Security=True";
        public LimitlessEntities() : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LimitlessEntities, Limitless.Data.Migrations.Configuration>(connectionString));
        }
        public DbSet<Hall> halls { get; set; }
        public DbSet<Classes> classeses { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Membership> memberships { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new HallConfiguration());
            //modelBuilder.Configurations.Add(new EventConfiguration());
            //modelBuilder.Configurations.Add(new ClassesConfiguration());
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

      

        public System.Data.Entity.DbSet<Limitless.Model.User> Users { get; set; }
    }

}
