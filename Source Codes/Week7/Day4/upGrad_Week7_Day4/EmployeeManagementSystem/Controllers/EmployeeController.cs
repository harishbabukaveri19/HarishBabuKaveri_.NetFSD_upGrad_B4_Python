using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        // LIST + FILTER + SORT
        public IActionResult Index(string search, string department, string sortOrder)
        {
            var employees = _repo.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(search))
                employees = employees.Where(e => e.Name.Contains(search));

            if (!string.IsNullOrEmpty(department))
                employees = employees.Where(e => e.Department == department);

            employees = sortOrder == "desc"
                ? employees.OrderByDescending(e => e.Salary)
                : employees.OrderBy(e => e.Salary);

            return View(employees.ToList());
        }

        // CREATE
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var emp = _repo.GetById(id);
            if (emp == null) return NotFound();

            return View(emp);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // DELETE (GET – confirm page)
        public IActionResult Delete(int id)
        {
            var emp = _repo.GetById(id);
            if (emp == null) return NotFound();

            return View(emp);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}