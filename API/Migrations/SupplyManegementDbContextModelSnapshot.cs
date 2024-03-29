﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(SupplyManegementDbContext))]
    partial class SupplyManegementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Models.AccountForEmployee", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_account_employees");
                });

            modelBuilder.Entity("API.Models.AccountForVendor", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_account_vendors");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("account_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("role_guid");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid");

                    b.HasIndex("RoleGuid");

                    b.ToTable("tb_tr_account_roles");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.HasKey("Guid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("API.Models.TenderProject", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<int>("AdminApprovalStatus")
                        .HasColumnType("int")
                        .HasColumnName("admin_approval_status");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("budget");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<int>("ManagerApprovalStatus")
                        .HasColumnType("int")
                        .HasColumnName("manager_approval_status");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("project_name");

                    b.Property<Guid>("VendorGuid")
                        .HasColumnType("char(36)")
                        .HasColumnName("vendor_guid");

                    b.HasKey("Guid");

                    b.HasIndex("VendorGuid");

                    b.ToTable("tb_m_tender_projects");
                });

            modelBuilder.Entity("API.Models.Vendor", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<int>("AdminApprovalStatus")
                        .HasColumnType("int")
                        .HasColumnName("admin_approval_status");

                    b.Property<string>("BusinessField")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("business_field");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("company_name");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("company_type");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsInRegistrationProcess")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_register_process");

                    b.Property<int>("ManagerApprovalStatus")
                        .HasColumnType("int")
                        .HasColumnName("manager_approval_status");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("PhotoProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("photo_product");

                    b.HasKey("Guid");

                    b.HasIndex("Email", "PhoneNumber")
                        .IsUnique();

                    b.ToTable("tb_m_vendors");
                });

            modelBuilder.Entity("API.Models.AccountForEmployee", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithOne("AccountForEmployee")
                        .HasForeignKey("API.Models.AccountForEmployee", "Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.AccountForVendor", b =>
                {
                    b.HasOne("API.Models.Vendor", "Vendor")
                        .WithOne("AccountForVendor")
                        .HasForeignKey("API.Models.AccountForVendor", "Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.HasOne("API.Models.AccountForEmployee", "AccountForEmployee")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountForEmployee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Models.TenderProject", b =>
                {
                    b.HasOne("API.Models.Vendor", "Vendor")
                        .WithMany("TenderProjects")
                        .HasForeignKey("VendorGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("API.Models.AccountForEmployee", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Navigation("AccountForEmployee");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("API.Models.Vendor", b =>
                {
                    b.Navigation("AccountForVendor");

                    b.Navigation("TenderProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
