using EmployeeManagementSystem.Models;

public interface IEmployeeRepository
{
    List<Employee> GetAll();
    Employee? GetById(int id);
    void Add(Employee emp);
    void Update(Employee emp);
    void Delete(int id);
}