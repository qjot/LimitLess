using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Limitless.Data.Configuration;
using Limitless.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using Limitless.Data.Cofiguration;

namespace Limitless.Data
{
    public class LimitlessEntities : DbContext
    {
        private static string connectionString =
            @"Data Source=DESKTOP-K4473GC\SQLEXPRESS;Initial Catalog=LimitlessEntities;Integrated Security=True";
        public LimitlessEntities() : base(connectionString)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LimitlessEntities, Limitless.Data.Migrations.Configuration>(connectionString));
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LimitlessEntities, Limitless.Data.Migrations.Configuration>("connectionString"));

        }
        public DbSet<Hall> halls { get; set; }
        public DbSet<Classes> classeses { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Membership> memberships { get; set; }
        public DbSet<User> users { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new HallConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new ClassesConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins").HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles").HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserClaim>().ToTable("userClaims");
            modelBuilder.Entity<IdentityUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<User>().ToTable("Users", "dbo");
        }

        public System.Data.Entity.DbSet<Limitless.Model.ClassesType> ClassesTypes { get; set; }



        //public System.Data.Entity.DbSet<Limitless.Model.User> Users { get; set; }
    }

}
