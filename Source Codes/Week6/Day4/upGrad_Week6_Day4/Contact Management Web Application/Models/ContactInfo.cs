using System.ComponentModel.DataAnnotations;

namespace Contact_Management_Web_Application.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company Name is required")]

        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]

        public long? MobileNo { get; set; }

        [Required(ErrorMessage = "Designation is required")]

        public string Designation { get; set; }
    }
}