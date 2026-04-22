using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Employee> GetAll() => _context.Employees.ToList();

    public Employee? GetById(int id) =>
        _context.Employees.FirstOrDefault(e => e.Id == id);

    public void Add(Employee emp)
    {
        _context.Employees.Add(emp);
        _context.SaveChanges();
    }

    public void Update(Employee emp)
    {
        _context.Employees.Update(emp);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var emp = GetById(id);
        if (emp != null)
        {
            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }
    }
}