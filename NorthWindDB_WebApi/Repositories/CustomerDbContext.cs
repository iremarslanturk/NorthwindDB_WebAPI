using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Models;
using System.Data;

namespace NorthWindDB_WebApi.Repositories
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
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
