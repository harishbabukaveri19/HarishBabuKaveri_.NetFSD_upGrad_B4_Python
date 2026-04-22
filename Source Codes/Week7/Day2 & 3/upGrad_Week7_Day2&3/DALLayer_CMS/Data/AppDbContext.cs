using DALLayer_CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace DALLayer_CMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInfo>()
                .HasKey(c => c.ContactId);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Contacts)
                .HasForeignKey(c => c.DepartmentId);

            // 🔥 SEED DATA
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, CompanyName = "TCS" },
                new Company { CompanyId = 2, CompanyName = "Infosys" },
                new Company { CompanyId = 3, CompanyName = "Wipro" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "HR" },
                new Department { DepartmentId = 2, DepartmentName = "IT" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" }
            );
        }
    }
}