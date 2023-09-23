using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Models;

namespace NorthWindDB_WebApi.Repositories
{
    public class SupplierDbContext : DbContext
    {

        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options)
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }
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
