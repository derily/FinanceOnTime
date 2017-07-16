using OnTime.DataLayer.Entities;
using OnTime.DataLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.DataLayer
{
   public class OnTimeContext : DbContext
    {
        public OnTimeContext():base("DefaultConnection")
        {
            // Database.SetInitializer(new CreateDatabaseIfNotExists<OnTimeContext>());
            Database.SetInitializer<OnTimeContext>(new MigrateDatabaseToLatestVersion<OnTimeContext, Configuration>());
           // Database.SetInitializer<OnTimeContext>(null);
        }

        public DbSet<PageImage> Images { get; set; }
        public DbSet<WeChatAccount> WeChatAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public  DbSet<QQGroup> QQGroups { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
