using System.Data.Entity;
using Limitless.Data.Configuration;
using Limitless.Model;

namespace Limitless.Data
{
    public class LimitlessEntities : DbContext
    {
        public LimitlessEntities() : base("LimitlessEntities") { }
        public DbSet<Hall> halls { get; set; }
        public DbSet<Classes> classeses { get; set; }
        public DbSet<Timetable> timetables { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HallConfiguration());
            modelBuilder.Configurations.Add(new TimetableConfiguration());
            modelBuilder.Configurations.Add(new ClassesConfiguration());
        }

    }

}
