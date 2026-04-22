using Contact_Management_Web_Application.Models;

namespace Contact_Management_Web_Application.Services
{
    public class ContactService : IContactService
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>();

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }
    }
}