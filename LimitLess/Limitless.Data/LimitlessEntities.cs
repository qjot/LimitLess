﻿using System.Data.Entity;
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
        private static string connectionString = ConfigurationManager.AppSettings["connectionString"];
        public LimitlessEntities() : base(@"Data Source=CPX-E4M39MY2P7Q\SQLEXPRESS;Initial Catalog=Limitless;Integrated Security=True")
        {
            Database.SetInitializer<LimitlessEntities>(null);
        }
        public DbSet<Hall> halls { get; set; }
        public DbSet<ClassesType> classesesType { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Membership> memberships { get; set; }
        public DbSet<Logs> logs { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<PaymentData> paymentData { get; set; }
        public DbSet<PaymentDetails> paymentDetail { get; set; }
        public DbSet<PaymentType> paymentType { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new HallConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins").HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles").HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<User>().ToTable("Users", "dbo");
        }
    }

}
