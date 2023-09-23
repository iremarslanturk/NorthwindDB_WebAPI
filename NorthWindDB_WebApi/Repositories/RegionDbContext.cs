using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Models;

namespace NorthWindDB_WebApi.Repositories
{
    public class RegionDbContext : DbContext
    {

        public RegionDbContext(DbContextOptions<RegionDbContext> options) : base(options)
        {

        }
        public DbSet<Region> Region { get; set; }
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
