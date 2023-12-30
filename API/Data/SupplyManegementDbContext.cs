using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace API.Data
{
    public class SupplyManegementDbContext : DbContext
    {
        public SupplyManegementDbContext(DbContextOptions<SupplyManegementDbContext> options) : base(options) { }


        // Tables
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<TenderProject> TenderProjects { get; set; }

        public DbSet<AccountForEmployee> AccountForEmployees { get; set; }

        public DbSet<AccountForVendor> AccountForVendors { get; set; }

        public DbSet<AccountRole> AccountRoles { get; set; }

        public DbSet<Role> Roles { get; set; }


        // Configuration Database Relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

           // Contstraints Unique
           modelBuilder.Entity<Employee>().HasIndex(employee => new
            {
               employee.Email
            }).IsUnique();


            modelBuilder.Entity<Vendor>().HasIndex(vendor => new
             {
                 vendor.Email,
                 vendor.PhoneNumber
             }).IsUnique();


            // Vendor - TenderProject (One to Many)
            modelBuilder.Entity<Vendor>()
                .HasMany(vendor => vendor.TenderProjects)
                .WithOne(tenderProject => tenderProject.Vendor)
                .HasForeignKey(tenderProject => tenderProject.VendorGuid);

            // AccountForEmployee - Employee (One to One)
            modelBuilder.Entity<AccountForEmployee>()
                .HasOne(accountForEmployee => accountForEmployee.Employee)
                .WithOne(employee => employee.AccountForEmployee)
                .HasForeignKey<AccountForEmployee>(accountForEmployee => accountForEmployee.Guid);

            // AccountForEmployee - AccountRole (One to Many)
            modelBuilder.Entity<AccountForEmployee>()
                .HasMany(account => account.AccountRoles)
                .WithOne(accountRole => accountRole.AccountForEmployee)
                .HasForeignKey(accountRole => accountRole.AccountGuid);

            // AccountForVendor - Vendor (One to One)
            modelBuilder.Entity<AccountForVendor>()
                .HasOne(accountForVendor => accountForVendor.Vendor)
                .WithOne(Vendor => Vendor.AccountForVendor)
                .HasForeignKey<AccountForVendor>(accountForVendor => accountForVendor.Guid);

            // Role - AccountRole (One to Many)
            modelBuilder.Entity<Role>()
                .HasMany(role => role.AccountRoles)
                .WithOne(accountRole => accountRole.Role)
                .HasForeignKey(accountRole => accountRole.RoleGuid);
        }
    }
}
