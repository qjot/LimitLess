using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Limitless.Data.Configuration;
using Limitless.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Limitless.Data
{
    public class LimitlessEntities : DbContext
    {
        public LimitlessEntities() : base("LimitlessEntities")
        {
            Database.SetInitializer<LimitlessEntities>(new DropCreateDatabaseIfModelChanges<LimitlessEntities>());
        }
        public DbSet<Hall> halls { get; set; }
        public DbSet<Classes> classeses { get; set; }
        public DbSet<Timetable> timetables { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new HallConfiguration());
            //modelBuilder.Configurations.Add(new TimetableConfiguration());
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
