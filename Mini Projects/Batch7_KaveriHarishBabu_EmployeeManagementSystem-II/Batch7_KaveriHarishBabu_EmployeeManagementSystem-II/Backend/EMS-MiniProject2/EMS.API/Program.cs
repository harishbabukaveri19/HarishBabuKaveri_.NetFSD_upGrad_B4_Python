using Microsoft.EntityFrameworkCore;
using EMS.API.Data;
using EMS.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // , , ,  1. Register the AppDbContext with SQL Server , , , 
            var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connStr))
            {
                throw new InvalidOperationException("DefaultConnection is missing in configuration.");
            }

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connStr));

            // , , ,  2. Register Repositories & Services , , , 
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // We will create this service in the next step!
            builder.Services.AddScoped<IAuthService, AuthService>();

            // , , ,  3. Configure JWT Authentication , , , 
            var jwtKey = builder.Configuration["Jwt:Key"];
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!)),
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero // Tokens expire exactly when they are supposed to
                    };
                });

            // , , ,  4. Configure CORS , , , 
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    //policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500") // Live Server ports
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            // Add services to the container.

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // 1. Tell Swagger to add the "Authorize" button
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter your JWT token below.\r\n\r\nExample: 'eyJhbGciOiJIUzI1Ni...'"
                });

                // 2. Tell Swagger to automatically attach the token to all endpoints
                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(); 

            app.UseCors("AllowFrontend");

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

            app.Run();
        }
    }
}
