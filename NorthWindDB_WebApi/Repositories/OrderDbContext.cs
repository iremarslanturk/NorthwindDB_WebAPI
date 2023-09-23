using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Models;

namespace NorthWindDB_WebApi.Repositories
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDemographic>(a =>
            {
                a.Property<string>("CustomerTypeId");
                a.HasKey("CustomerTypeId");
            });

            modelBuilder.Entity<OrderDetail>(a =>
            {
                a.Property<int>("OrderId");
                a.HasKey("OrderId");
            });
            modelBuilder.Entity<Order>(entity =>
            {
               
                entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers"); 
            });
        }
    }
}
