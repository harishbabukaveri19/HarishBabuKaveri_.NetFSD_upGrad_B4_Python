using Moq;
using EMS.API.DTOs; 
using EMS.API.Models;
using EMS.API.Services;

namespace EMS.Tests.Services
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _repoMock;
        private EmployeeService _service;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IEmployeeRepository>();
            // Assuming your service takes the repository interface in its constructor
            _service = new EmployeeService(_repoMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_ValidId_ReturnsMappedDto()
        {
            // Arrange
            var fakeEmployee = new EmployeeResponseDto
            {
                Id = 1,
                FirstName = "Priya",
                LastName = "Prabhu",
                Email = "p@h.com",
                Status = "Active"
            };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(fakeEmployee);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo("Priya"));
            _repoMock.Verify(r => r.GetByIdAsync(1), Times.Once);
        }

        [Test]
        public async Task GetByIdAsync_InvalidId_ReturnsNull()
        {
            // Arrange
            _repoMock.Setup(r => r.GetByIdAsync(9999)).ReturnsAsync((EmployeeResponseDto)null);

            // Act
            var result = await _service.GetByIdAsync(9999);

            // Assert
            Assert.That(result, Is.Null);
            _repoMock.Verify(r => r.GetByIdAsync(9999), Times.Once);
        }

        [Test]
        public async Task CreateAsync_ValidEmployee_CallsAddAsyncOnRepo()
        {
            // Arrange
            var newEmpDto = new EmployeeRequestDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com"
            };

            // Act
            await _service.CreateAsync(newEmpDto);

            // Assert
            // Verify that AddAsync was called exactly once with any Employee object
            _repoMock.Verify(r => r.AddAsync(It.IsAny<Employee>()), Times.Once);
        }
    }
}