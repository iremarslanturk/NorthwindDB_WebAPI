﻿using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Models;

namespace NorthWindDB_WebApi.Repositories
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
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
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasOne(e => e.ReportsToNavigation)
                    .WithMany(e => e.InverseReportsToNavigation)
                    .HasForeignKey(e => e.ReportsTo)
                    .OnDelete(DeleteBehavior.NoAction); 
            });
        }
    }
}
