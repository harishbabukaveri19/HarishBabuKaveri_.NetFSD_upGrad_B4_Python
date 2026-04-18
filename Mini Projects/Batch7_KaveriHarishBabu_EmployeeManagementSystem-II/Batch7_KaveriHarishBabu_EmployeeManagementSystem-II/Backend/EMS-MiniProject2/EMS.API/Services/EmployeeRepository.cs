using Microsoft.EntityFrameworkCore;
using EMS.API.Data;
using EMS.API.DTOs;
using EMS.API.Models;

namespace EMS.API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        private static EmployeeResponseDto MapToDto(Employee e) => new EmployeeResponseDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            Phone = e.Phone,
            Department = e.Department,
            Designation = e.Designation,
            Salary = e.Salary,
            JoinDate = e.JoinDate,
            Gender = e.Gender,
            Status = e.Status
        };

        public async Task<PagedResult<EmployeeResponseDto>> GetEmployeesAsync(string? search, string? department, string? status, string? sortBy, string? sortDir, int page, int pageSize)
        {
            var query = _context.Employees.AsQueryable();

            // 1. Filtering
            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(e => (e.FirstName + " " + e.LastName).Contains(search) || e.Email.Contains(search));

            if (!string.IsNullOrWhiteSpace(department))
                query = query.Where(e => e.Department == department);

            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(e => e.Status == status);

            // 2. Sorting
            bool isDesc = sortDir?.ToLower() == "desc";
            query = sortBy?.ToLower() switch
            {
                "id" => isDesc ? query.OrderByDescending(e => e.Id) : query.OrderBy(e => e.Id),
                "name" => isDesc ? query.OrderByDescending(e => e.LastName).ThenByDescending(e => e.FirstName) : query.OrderBy(e => e.LastName).ThenBy(e => e.FirstName),
                "salary" => isDesc ? query.OrderByDescending(e => e.Salary) : query.OrderBy(e => e.Salary),
                "joindate" => isDesc ? query.OrderByDescending(e => e.JoinDate) : query.OrderBy(e => e.JoinDate),
                _ => query.OrderByDescending(e => e.Id) // Default sort
            };

            // 3. Pagination
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<EmployeeResponseDto>
            {
                Data = items.Select(MapToDto),
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<EmployeeResponseDto?> GetByIdAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            return emp == null ? null : MapToDto(emp);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateAsync(int id, EmployeeRequestDto dto)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return null;

            emp.FirstName = dto.FirstName;
            emp.LastName = dto.LastName;
            emp.Email = dto.Email;
            emp.Phone = dto.Phone;
            emp.Department = dto.Department;
            emp.Designation = dto.Designation;
            emp.Salary = dto.Salary;
            emp.JoinDate = dto.JoinDate;
            emp.Gender = dto.Gender;
            emp.Status = dto.Status;
            emp.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return false;

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DashboardSummaryDto> GetDashboardSummaryAsync()
        {
            var allEmps = await _context.Employees.ToListAsync();

            var breakdown = allEmps.GroupBy(e => e.Department)
                                   .Select(g => new {
                                       department = g.Key,
                                       count = g.Count(),
                                       percentage = allEmps.Count > 0 ? (int)Math.Round((double)g.Count() / allEmps.Count * 100) : 0
                                   })
                                   .OrderByDescending(x => x.count).ToList();

            var recent = allEmps.OrderByDescending(e => e.CreatedAt).Take(5).Select(MapToDto).ToList();

            return new DashboardSummaryDto
            {
                Total = allEmps.Count,
                Active = allEmps.Count(e => e.Status == "Active"),
                Inactive = allEmps.Count(e => e.Status == "Inactive"),
                Departments = breakdown.Count,
                DepartmentBreakdown = breakdown,
                RecentEmployees = recent
            };
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            // Checks if any employee has this email, ignoring the current employee if we are editing
            return await _context.Employees
                .AnyAsync(e => e.Email.ToLower() == email.ToLower() && e.Id != excludeId);
        }

        public async Task<bool> PhoneExistsAsync(string phone, int? excludeId = null)
        {
            return await _context.Employees
                .AnyAsync(e => e.Phone == phone && e.Id != excludeId);
        }
    }
}