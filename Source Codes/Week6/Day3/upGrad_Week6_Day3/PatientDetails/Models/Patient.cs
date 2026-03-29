using System.ComponentModel.DataAnnotations;

namespace PatientDetails.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 120, ErrorMessage = "Enter valid age")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Disease is required")]
        public string Disease { get; set; }
    }
}