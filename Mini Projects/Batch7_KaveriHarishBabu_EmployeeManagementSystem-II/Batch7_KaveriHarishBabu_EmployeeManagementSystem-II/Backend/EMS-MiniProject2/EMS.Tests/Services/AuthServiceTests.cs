using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using EMS.API.Data;
using EMS.API.Services;
using EMS.API.Models;
using EMS.API.DTOs;
using System.Threading.Tasks;
using System;

namespace EMS.Tests.Services
{
    [TestFixture]
    public class AuthServiceTests
    {
        private AppDbContext _db;
        private Mock<IConfiguration> _mockConfig;
        private AuthService _svc;

        [SetUp]
        public void Setup()
        {
            // Set up an isolated In-Memory database for each test
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _db = new AppDbContext(options);

            // Seed a test user
            _db.AppUsers.Add(new AppUser { Username = "admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), Role = "Admin" });
            _db.SaveChanges();

            // Mock the JWT Configuration
            _mockConfig = new Mock<IConfiguration>();
            _mockConfig.Setup(c => c["Jwt:Key"]).Returns("TestSecretKey_32Chars_ForNUnit!!");
            _mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("EMS.API");
            _mockConfig.Setup(c => c["Jwt:Audience"]).Returns("EMS.Client");

            _svc = new AuthService(_db, _mockConfig.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _db.Database.EnsureDeleted();
            _db.Dispose();
        }

        [Test]
        public async Task LoginAsync_ValidCredentials_ReturnsTokenString()
        {
            // Act
            var request = new AuthRequestDto { Username = "admin", Password = "admin123" };
            var result = await _svc.LoginAsync(request);

            // Assert
            Assert.That(result.Success, Is.True);
            Assert.That(result.Token, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task LoginAsync_WrongPassword_ReturnsFailure()
        {
            // Act
            var request = new AuthRequestDto { Username = "admin", Password = "wrongpassword" };
            var result = await _svc.LoginAsync(request);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.Token, Is.Null.Or.Empty);
        }

        [Test]
        public async Task RegisterAsync_DuplicateUsername_ReturnsFailure()
        {
            // Act - Try to register "admin" again
            var request = new AuthRequestDto { Username = "admin", Password = "newpassword" };
            var result = await _svc.RegisterAsync(request);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.Message, Does.Contain("already exists").IgnoreCase);
        }
    }
}