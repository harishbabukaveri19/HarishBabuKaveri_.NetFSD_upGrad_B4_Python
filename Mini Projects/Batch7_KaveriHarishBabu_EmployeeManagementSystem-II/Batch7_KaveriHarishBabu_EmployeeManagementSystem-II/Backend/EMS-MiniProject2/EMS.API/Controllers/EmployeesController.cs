using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EMS.API.DTOs;
using EMS.API.Models;
using EMS.API.Services;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires a valid JWT token for ALL endpoints in this controller
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<EmployeeResponseDto>>> GetEmployees(
            [FromQuery] string? search, [FromQuery] string? department, [FromQuery] string? status,
            [FromQuery] string? sortBy = "id", [FromQuery] string? sortDir = "asc",
            [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            // Cap page size as per requirements
            pageSize = pageSize > 100 ? 100 : pageSize;
            var result = await _repository.GetEmployeesAsync(search, department, status, sortBy, sortDir, page, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponseDto>> GetEmployee(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardSummaryDto>> GetDashboard()
        {
            return Ok(await _repository.GetDashboardSummaryAsync());
        }

        // --- WRITE OPERATIONS (ADMIN ONLY) ---
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeRequestDto dto)
        {
            // 1. Check BOTH before stopping
            bool emailConflict = await _repository.EmailExistsAsync(dto.Email);
            bool phoneConflict = await _repository.PhoneExistsAsync(dto.Phone);

            if (emailConflict || phoneConflict)
            {
                string errorMsg = "";
                if (emailConflict) errorMsg += "Email: This email is already in use. ";
                if (phoneConflict) errorMsg += "Phone: This phone number is already registered.";

                return Conflict(new { message = errorMsg });
            }

            var emp = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Department = dto.Department,
                Designation = dto.Designation,
                Salary = dto.Salary,
                JoinDate = dto.JoinDate,
                Gender = dto.Gender,
                Status = dto.Status
            };

            await _repository.AddAsync(emp);
            return CreatedAtAction(nameof(GetEmployee), new { id = emp.Id }, emp);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeRequestDto dto)
        {
            // 1. Check BOTH before stopping
            bool emailConflict = await _repository.EmailExistsAsync(dto.Email, id);
            bool phoneConflict = await _repository.PhoneExistsAsync(dto.Phone, id);

            if (emailConflict || phoneConflict)
            {
                string errorMsg = "";
                if (emailConflict) errorMsg += "Email: This email address is already exist.";
                if (phoneConflict) errorMsg += "Phone: This phone number is already exist.";

                return Conflict(new { message = errorMsg });
            }

            var updated = await _repository.UpdateAsync(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}