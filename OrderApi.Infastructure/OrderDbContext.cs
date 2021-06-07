using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.OrderAggreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Infastructure
{
    public class OrderDbContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "ordering";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS01;Database=OrderDbDb;Integrated Security=true;");
        }
       
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders", DEFAULT_SCHEMA);
            modelBuilder.Entity<Order>().OwnsOne(p => p.Adress).WithOwner();
        }
    }
}
