using EMS.API.DTOs;
using EMS.API.Models;

namespace EMS.API.Services
{
    public interface IEmployeeRepository
    {
        Task<PagedResult<EmployeeResponseDto>> GetEmployeesAsync(string? search, string? department, string? status, string? sortBy, string? sortDir, int page, int pageSize);
        Task<EmployeeResponseDto?> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task<Employee?> UpdateAsync(int id, EmployeeRequestDto employeeDto);
        Task<bool> DeleteAsync(int id);
        Task<DashboardSummaryDto> GetDashboardSummaryAsync();
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);
        Task<bool> PhoneExistsAsync(string phone, int? excludeId = null);
    }
}