using DALLayer_CMS.Data;
using DALLayer_CMS.Models;
using DALLayer_CMS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DALUILayer_CMS.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;
        private readonly AppDbContext _context;

        public ContactController(IContactRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        // ✅ GET: /Contact/ShowContacts
        [HttpGet]
        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        // ✅ GET: /Contact/GetContactById/1
        [HttpGet]
        public IActionResult GetContactById(int id)
        {
            var contact = _repo.GetContactById(id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // ✅ GET: /Contact/AddContact
        [HttpGet]
        public IActionResult AddContact()
        {
            LoadDropdowns();
            return View();
        }

        // ✅ POST: /Contact/AddContact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(contact);
            }

            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        // ✅ GET: /Contact/EditContact/1
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);

            if (contact == null)
                return NotFound();

            LoadDropdowns();
            return View(contact);
        }

        // ✅ POST: /Contact/EditContact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(contact);
            }

            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        // ✅ GET: /Contact/DeleteContact/1
        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            var contact = _repo.GetContactById(id);

            if (contact == null)
                return NotFound();

            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(
                _context.Companies.ToList(),
                "CompanyId",
                "CompanyName"
            );

            ViewBag.Departments = new SelectList(
                _context.Departments.ToList(),
                "DepartmentId",
                "DepartmentName"
            );
        }
    }
}