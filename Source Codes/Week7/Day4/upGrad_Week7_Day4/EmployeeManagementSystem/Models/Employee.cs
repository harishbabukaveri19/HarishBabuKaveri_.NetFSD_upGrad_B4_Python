using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        [Range(1000, 1000000)]
        [Column(TypeName = "decimal(18,2)")] // ✅ Fix precision issue
        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        public string JobTitle { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}