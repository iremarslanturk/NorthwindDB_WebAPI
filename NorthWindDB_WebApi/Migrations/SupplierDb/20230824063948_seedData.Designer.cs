﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorthWindDB_WebApi.Repositories;

#nullable disable

namespace NorthWindDB_WebApi.Migrations.SupplierDb
{
    [DbContext(typeof(SupplierDbContext))]
    [Migration("20230824063948_seedData")]
    partial class seedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerCustomerDemographic", b =>
                {
                    b.Property<string>("CustomerTypesCustomerTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomersCustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerTypesCustomerTypeId", "CustomersCustomerId");

                    b.HasIndex("CustomersCustomerId");

                    b.ToTable("CustomerCustomerDemographic");
                });

            modelBuilder.Entity("EmployeeTerritory", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("TerritoriesTerritoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EmployeesEmployeeId", "TerritoriesTerritoryId");

                    b.HasIndex("TerritoriesTerritoryId");

                    b.ToTable("EmployeeTerritory");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.CustomerDemographic", b =>
                {
                    b.Property<string>("CustomerTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerTypeId");

                    b.ToTable("CustomerDemographic");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<int?>("ReportsToNavigationEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleOfCourtesy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ReportsToNavigationEmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Freight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RequiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipRegion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShipVia")
                        .HasColumnType("int");

                    b.Property<int?>("ShipViaNavigationShipperId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShipViaNavigationShipperId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<int>("OrderId1")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderId1");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuantityPerUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("ReorderLevel")
                        .HasColumnType("smallint");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short?>("UnitsInStock")
                        .HasColumnType("smallint");

                    b.Property<short?>("UnitsOnOrder")
                        .HasColumnType("smallint");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionId"));

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Shipper", b =>
                {
                    b.Property<int>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipperId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipperId");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Territory", b =>
                {
                    b.Property<string>("TerritoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TerritoryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Territory");
                });

            modelBuilder.Entity("CustomerCustomerDemographic", b =>
                {
                    b.HasOne("NorthWindDB_WebApi.Models.CustomerDemographic", null)
                        .WithMany()
                        .HasForeignKey("CustomerTypesCustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthWindDB_WebApi.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeTerritory", b =>
                {
                    b.HasOne("NorthWindDB_WebApi.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthWindDB_WebApi.Models.Territory", null)
                        .WithMany()
                        .HasForeignKey("TerritoriesTerritoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Employee", b =>
                {
                    b.HasOne("NorthWindDB_WebApi.Models.Employee", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsToNavigationEmployeeId");

                    b.Navigation("ReportsToNavigation");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Order", b =>
                {
                    b.HasOne("NorthWindDB_WebApi.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("NorthWindDB_WebApi.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("NorthWindDB_WebApi.Models.Shipper", "ShipViaNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("ShipViaNavigationShipperId");

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("ShipViaNavigation");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.OrderDetail", b =>
                {
                    b.HasOne("NorthWindDB_WebApi.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthWindDB_WebApi.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Product", b =>
                {
                    b.HasOne("NorthWindDB_WebApi.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("NorthWindDB_WebApi.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Territory", b =>
                {
                    b.HasOne("NorthWindDB_WebApi.Models.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Employee", b =>
                {
                    b.Navigation("InverseReportsToNavigation");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Region", b =>
                {
                    b.Navigation("Territories");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Shipper", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("NorthWindDB_WebApi.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
