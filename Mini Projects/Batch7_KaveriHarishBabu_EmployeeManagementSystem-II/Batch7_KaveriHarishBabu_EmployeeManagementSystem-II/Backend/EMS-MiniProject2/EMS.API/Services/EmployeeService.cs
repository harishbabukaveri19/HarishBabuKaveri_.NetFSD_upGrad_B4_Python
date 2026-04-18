using System.Threading.Tasks;
using EMS.API.DTOs;
using EMS.API.Models;

namespace EMS.API.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        // The tests inject the Mock Repository here!
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeResponseDto> GetByIdAsync(int id)
        {
            // Just passes the call down to the repository
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(EmployeeRequestDto employeeDto)
        {
            // 1. Check for duplicates
            if (await _repository.EmailExistsAsync(employeeDto.Email))
            {
                throw new InvalidOperationException("Email: This email address is already exist.");
            }

            if (await _repository.PhoneExistsAsync(employeeDto.Phone))
            {
                throw new InvalidOperationException("Phone: This phone number is already exist.");
            }

            // 2. If no duplicates, map and save
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                // ... map other fields ...
            };

            await _repository.AddAsync(employee);
        }
    }
}