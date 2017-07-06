using OnTime.DataLayer.Entities;
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
                
        }

        public DbSet<PageImage> Images { get; set; }
        public DbSet<WeChatAccount> WeChatAccounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
