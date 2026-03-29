using Contact_Management_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Contact_Management_Web_Application.Controllers
{
    public class ContactController : Controller
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName = "Harish", LastName = "Babu", CompanyName="ABC", EmailId="harish@gmail.com", MobileNo=9874561023, Designation="Manager" }
        };

        // SHOW + SEARCH
        public IActionResult ShowContacts(string search)
        {
            var result = contacts;

            if (!string.IsNullOrEmpty(search))
            {
                result = contacts
                    .Where(x => x.FirstName.ToLower().Contains(search.ToLower()) ||
                                x.LastName.ToLower().Contains(search.ToLower()))
                    .ToList();
            }

            return View(result);
        }

        // DETAILS
        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            return View(contact);
        }

        // ADD (GET)
        public IActionResult AddContact()
        {
            return View();
        }

        // ADD (POST)
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
                return View(contactInfo);

            contactInfo.ContactId = contacts.Any() ? contacts.Max(x => x.ContactId) + 1 : 1;
            contacts.Add(contactInfo);

            return RedirectToAction("ShowContacts");
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            return View(contact);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(ContactInfo updated)
        {
            if (!ModelState.IsValid)
                return View(updated);

            var contact = contacts.FirstOrDefault(x => x.ContactId == updated.ContactId);

            if (contact != null)
            {
                contact.FirstName = updated.FirstName;
                contact.LastName = updated.LastName;
                contact.CompanyName = updated.CompanyName;
                contact.EmailId = updated.EmailId;
                contact.MobileNo = updated.MobileNo;
                contact.Designation = updated.Designation;
            }

            return RedirectToAction("ShowContacts");
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            return View(contact);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);

            if (contact != null)
            {
                contacts.Remove(contact);
            }

            return RedirectToAction("ShowContacts");
        }
    }
}