using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMS.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedAt", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 16, 13, 38, 5, 256, DateTimeKind.Utc).AddTicks(7334), "$2a$11$jktJGI4pCemEIvvncmPY.O9BYGjN/ymWqMXvzM8SbKREukHBGh4/m", "Admin", "admin" },
                    { 2, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(8051), "$2a$11$W1Fz7NA0XGp6LlM7SfHBv.cWxWeG81IRhCTvQnuomwohlztTkDu56", "Viewer", "viewer" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "Department", "Designation", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Phone", "Salary", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9001), "Engineering", "Software Engineer", "harishbabu.k@gmail.com", "Harish Babu", "Male", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaveri", "9876543210", 850000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9003) },
                    { 2, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9019), "Marketing", "Marketing Exec", "balaji.m@gmail.com", "Balaji", "Male", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marathi", "9123456780", 620000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9020) },
                    { 3, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9024), "HR", "HR Executive", "harika.anam@gmail.com", "Harika", "Female", new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anam", "9876512340", 550000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9024) },
                    { 4, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9027), "Finance", "Financial Analyst", "poojitha.k@gmail.com", "Poojitha", "Female", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaveri", "9988776655", 720000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9027) },
                    { 5, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9030), "Operations", "Operations Mgr", "ajaykumar.p@gmail.com", "Ajay Kumar", "Male", new DateTime(2018, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poola", "9123123123", 950000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9030) },
                    { 6, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9033), "Engineering", "Senior Dev", "tejaswini.reddy@gmail.com", "Tejaswini", "Female", new DateTime(2017, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy", "9988998899", 1100000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9033) },
                    { 7, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9230), "Marketing", "Content Strategist", "pavankumar.m@gmail.com", "Pavan Kumar", "Male", new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mavilla", "9001002003", 580000m, "Inactive", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9230) },
                    { 8, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9234), "Finance", "Accounts Mgr", "tharunsangeeth.k@gmail.com", "Tharun Sangeeth", "Male", new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katuru", "9112233445", 800000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9234) },
                    { 9, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9237), "Engineering", "DevOps Eng", "harshitha.sree@gmail.com", "Harshitha", "Female", new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sree", "9998887776", 900000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9237) },
                    { 10, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9243), "Operations", "Supply Chain Analyst", "vamsi.n@gmail.com", "Vamsi", "Male", new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nallamangala", "9887766554", 650000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9243) },
                    { 11, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9246), "Marketing", "Brand Manager", "rohith.n@gmail.com", "Rohith", "Male", new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neeli", "9776655443", 820000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9246) },
                    { 12, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9248), "Finance", "Tax Consultant", "vamsi.krishna@gmail.com", "Vamsi", "Male", new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krishna", "9665544332", 750000m, "Inactive", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9249) },
                    { 13, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9251), "Engineering", "QA Engineer", "sai.vikas@gmail.com", "Sai", "Male", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vikas", "9554433221", 680000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9251) },
                    { 14, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9253), "HR", "Recruiter", "nandhakishore.a@gmail.com", "Nandha Kishore", "Male", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akkineni", "9443322110", 500000m, "Active", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9253) },
                    { 15, new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9270), "Operations", "Logistics Coord", "laxmiprasanna.m@gmail.com", "Laxmi Prasanna", "Female", new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mandava", "9332211009", 540000m, "Inactive", new DateTime(2026, 4, 16, 13, 38, 5, 396, DateTimeKind.Utc).AddTicks(9271) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Username",
                table: "AppUsers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
