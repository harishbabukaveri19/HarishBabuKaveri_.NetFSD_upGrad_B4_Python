using Microsoft.EntityFrameworkCore;
using EMS.API.Models;

namespace EMS.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Enforce unique constraints (as required by the project specs)
            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            // 2. Seed Default Users (Passwords MUST be hashed before going into the DB)
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow
                },
                new AppUser
                {
                    Id = 2,
                    Username = "viewer",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("viewer123"),
                    Role = "Viewer",
                    CreatedAt = DateTime.UtcNow
                }
            );

            // 3. Seed Initial Employees (Migrated from your old data.js)
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Harish Babu", LastName = "Kaveri", Email = "harishbabu.k@gmail.com", Phone = "9876543210", Department = "Engineering", Designation = "Software Engineer", Salary = 850000, JoinDate = new DateTime(2021, 3, 15), Gender = "Male", Status = "Active" },
                new Employee { Id = 2, FirstName = "Balaji", LastName = "Marathi", Email = "balaji.m@gmail.com", Phone = "9123456780", Department = "Marketing", Designation = "Marketing Exec", Salary = 620000, JoinDate = new DateTime(2020, 7, 1), Gender = "Male", Status = "Active" },
                new Employee { Id = 3, FirstName = "Harika", LastName = "Anam", Email = "harika.anam@gmail.com", Phone = "9876512340", Department = "HR", Designation = "HR Executive", Salary = 550000, JoinDate = new DateTime(2019, 11, 20), Gender = "Female", Status = "Active" },
                new Employee { Id = 4, FirstName = "Poojitha", LastName = "Kaveri", Email = "poojitha.k@gmail.com", Phone = "9988776655", Department = "Finance", Designation = "Financial Analyst", Salary = 720000, JoinDate = new DateTime(2022, 1, 10), Gender = "Female", Status = "Active" },
                new Employee { Id = 5, FirstName = "Ajay Kumar", LastName = "Poola", Email = "ajaykumar.p@gmail.com", Phone = "9123123123", Department = "Operations", Designation = "Operations Mgr", Salary = 950000, JoinDate = new DateTime(2018, 5, 5), Gender = "Male", Status = "Active" },
                new Employee { Id = 6, FirstName = "Tejaswini", LastName = "Reddy", Email = "tejaswini.reddy@gmail.com", Phone = "9988998899", Department = "Engineering", Designation = "Senior Dev", Salary = 1100000, JoinDate = new DateTime(2017, 09, 12), Gender = "Female", Status = "Active" },
                new Employee { Id = 7, FirstName = "Pavan Kumar", LastName = "Mavilla", Email = "pavankumar.m@gmail.com", Phone = "9001002003", Department = "Marketing", Designation = "Content Strategist", Salary = 580000, JoinDate = new DateTime(2023, 02, 28), Gender = "Male", Status = "Inactive" },
                new Employee { Id = 8, FirstName = "Tharun Sangeeth", LastName = "Katuru", Email = "tharunsangeeth.k@gmail.com", Phone = "9112233445", Department = "Finance", Designation = "Accounts Mgr", Salary = 800000, JoinDate = new DateTime(2020, 04, 17), Gender = "Male", Status = "Active" },
                new Employee { Id = 9, FirstName = "Harshitha", LastName = "Sree", Email = "harshitha.sree@gmail.com", Phone = "9998887776", Department = "Engineering", Designation = "DevOps Eng", Salary = 900000, JoinDate = new DateTime(2021, 08, 22), Gender = "Female", Status = "Active" },
                new Employee { Id = 10, FirstName = "Vamsi", LastName = "Nallamangala", Email = "vamsi.n@gmail.com", Phone = "9887766554", Department = "Operations", Designation = "Supply Chain Analyst", Salary = 650000, JoinDate = new DateTime(2022, 11, 15), Gender = "Male", Status = "Active" },
                new Employee { Id = 11, FirstName = "Rohith", LastName = "Neeli", Email = "rohith.n@gmail.com", Phone = "9776655443", Department = "Marketing", Designation = "Brand Manager", Salary = 820000, JoinDate = new DateTime(2019, 03, 10), Gender = "Male", Status = "Active" },
                new Employee { Id = 12, FirstName = "Vamsi", LastName = "Krishna", Email = "vamsi.krishna@gmail.com", Phone = "9665544332", Department = "Finance", Designation = "Tax Consultant", Salary = 750000, JoinDate = new DateTime(2021, 06, 05), Gender = "Male", Status = "Inactive" },
                new Employee { Id = 13, FirstName = "Sai", LastName = "Vikas", Email = "sai.vikas@gmail.com", Phone = "9554433221", Department = "Engineering", Designation = "QA Engineer", Salary = 680000, JoinDate = new DateTime(2022, 09, 01), Gender = "Male", Status = "Active" },
                new Employee { Id = 14, FirstName = "Nandha Kishore", LastName = "Akkineni", Email = "nandhakishore.a@gmail.com", Phone = "9443322110", Department = "HR", Designation = "Recruiter", Salary = 500000, JoinDate = new DateTime(2023, 01, 20), Gender = "Male", Status = "Active" },
                new Employee { Id = 15, FirstName = "Laxmi Prasanna", LastName = "Mandava", Email = "laxmiprasanna.m@gmail.com", Phone = "9332211009", Department = "Operations", Designation = "Logistics Coord", Salary = 540000, JoinDate = new DateTime(2020, 10, 12), Gender = "Female", Status = "Inactive" }


                // Note: You can add the rest of your 15 employees here following this exact pattern!
            );
        }
    }
}