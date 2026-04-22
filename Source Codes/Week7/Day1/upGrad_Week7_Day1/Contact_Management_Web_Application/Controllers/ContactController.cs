using Contact_Management_Web_Application.Models;
using Contact_Management_Web_Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Show all contacts
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // FIXED: Handle null ID
        public IActionResult GetContactById(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Search");
            }

            var contact = _contactService.GetContactById(id.Value);

            return View(contact);
        }

        // NEW: Search Page (GET)
        public IActionResult Search()
        {
            return View();
        }

        // NEW: Search (POST)
        [HttpPost]
        public IActionResult Search(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View("GetContactById", contact);
        }

        // GET: Add Contact
        public IActionResult AddContact()
        {
            return View();
        }

        // POST: Add Contact
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}