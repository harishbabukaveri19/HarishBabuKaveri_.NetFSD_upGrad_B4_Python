using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EMS.API.Controllers;
using EMS.API.DTOs;
using EMS.API.Models;
using EMS.API.Services;
using System.Threading.Tasks;

namespace EMS.Tests.Controllers
{
    [TestFixture]
    public class EmployeesControllerTests
    {
        private Mock<IEmployeeRepository> _mockRepo;
        private EmployeesController _controller;

        [SetUp]
        public void Setup()
        {
            // We mock the repository so we are ONLY testing the Controller's logic
            _mockRepo = new Mock<IEmployeeRepository>();
            _controller = new EmployeesController(_mockRepo.Object);
        }

        [Test]
        public async Task GetEmployee_ValidId_ReturnsOkObjectResult()
        {
            // Arrange
            var fakeDto = new EmployeeResponseDto { Id = 1, FirstName = "Tony", LastName = "Stark" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(fakeDto);

            // Act
            var result = await _controller.GetEmployee(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(fakeDto));
        }

        [Test]
        public async Task GetEmployee_InvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetByIdAsync(9999)).ReturnsAsync((EmployeeResponseDto)null);

            // Act
            var result = await _controller.GetEmployee(9999);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task CreateEmployee_DuplicateEmail_ReturnsConflict()
        {
            // Arrange - Simulate a duplicate email being found
            var request = new EmployeeRequestDto { Email = "duplicate@test.com", Phone = "1234567890" };
            _mockRepo.Setup(r => r.EmailExistsAsync(request.Email, null)).ReturnsAsync(true);
            _mockRepo.Setup(r => r.PhoneExistsAsync(request.Phone, null)).ReturnsAsync(false);

            // Act
            var result = await _controller.CreateEmployee(request);

            // Assert - The controller should return our custom 409 Conflict message
            Assert.That(result.Result, Is.InstanceOf<ConflictObjectResult>());
        }

        [Test]
        public async Task CreateEmployee_ValidData_ReturnsCreatedAtAction()
        {
            // Arrange - Simulate clean data with no duplicates
            var request = new EmployeeRequestDto { FirstName = "New", Email = "new@test.com", Phone = "1234567890" };
            _mockRepo.Setup(r => r.EmailExistsAsync(It.IsAny<string>(), null)).ReturnsAsync(false);
            _mockRepo.Setup(r => r.PhoneExistsAsync(It.IsAny<string>(), null)).ReturnsAsync(false);

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Employee>())).ReturnsAsync(new Employee { Id = 1 });

            // Act
            var result = await _controller.CreateEmployee(request);

            // Assert - The controller should return a 201 Created Status
            Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
        }
    }
}