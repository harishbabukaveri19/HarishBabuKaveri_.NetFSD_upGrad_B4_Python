using System.ComponentModel.DataAnnotations;

namespace EMS.API.DTOs
{
    // What we send TO the frontend
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    // What we accept FROM the frontend (with validation)
    public class EmployeeRequestDto
    {
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string Phone { get; set; } = string.Empty;
        [Required] public string Department { get; set; } = string.Empty;
        [Required] public string Designation { get; set; } = string.Empty;
        [Required] public decimal Salary { get; set; }
        [Required] public DateTime JoinDate { get; set; }
        [Required] public string Gender { get; set; } = string.Empty;
        [Required] public string Status { get; set; } = "Active";
    }

    // The pagination envelope exactly as required by your syllabus
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasNextPage => Page < TotalPages;
        public bool HasPrevPage => Page > 1;
    }

    public class DashboardSummaryDto
    {
        public int Total { get; set; }
        public int Active { get; set; }
        public int Inactive { get; set; }
        public int Departments { get; set; }
        public object? DepartmentBreakdown { get; set; }
        public IEnumerable<EmployeeResponseDto> RecentEmployees { get; set; } = new List<EmployeeResponseDto>();
    }
}