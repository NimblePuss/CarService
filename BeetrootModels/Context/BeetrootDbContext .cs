using System;
using System.Collections.Generic;
using System.Text;
using BeetrootModels.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BeetrootModels.Context
{
    public class BeetrootDbContext: DbContext
    {
        public BeetrootDbContext(DbContextOptions<BeetrootDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)       
        {

            modelBuilder.Entity<Order>().HasOne(d => d.PersonalInfo)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PersonInfoId)
                    .OnDelete(DeleteBehavior.Cascade);
            

            modelBuilder.Entity<OrderService>().HasKey(os => new { os.OrderId, os.ServiceId });

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PersonalInfo> PersonInfos { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
    }
}
