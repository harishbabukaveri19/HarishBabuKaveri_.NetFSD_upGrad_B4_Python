using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();

    if (!context.Employees.Any())
    {
        context.Employees.AddRange(
            new Employee
            {
                Name = "Harish",
                Department = "IT",
                Salary = 50000,
                HireDate = DateTime.Now,
                JobTitle = "Developer",
                IsActive = true
            },
            new Employee
            {
                Name = "Ravi",
                Department = "HR",
                Salary = 40000,
                HireDate = DateTime.Now,
                JobTitle = "HR Manager",
                IsActive = true
            },
            new Employee
            {
                Name = "Anita",
                Department = "Finance",
                Salary = 60000,
                HireDate = DateTime.Now,
                JobTitle = "Accountant",
                IsActive = true
            }
        );

        context.SaveChanges();
    }
}

app.Run();
