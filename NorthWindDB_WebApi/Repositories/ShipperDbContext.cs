using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Models;

namespace NorthWindDB_WebApi.Repositories
{
    public class ShipperDbContext : DbContext
    {
        public ShipperDbContext(DbContextOptions<ShipperDbContext> options) : base(options)
        {

        }
        public DbSet<Shipper> Shippers { get; set; }
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
        }
    }
}
