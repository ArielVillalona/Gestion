using RepublicaEmpleos.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace RepublicaEmpleos.Models
{
    public class ProfileViewModel
    {
        [StringLength(100, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public Profile Profile { get; set; }
        public ApplicationUser account { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public MatiralStatus MatiralStatus { get; set; }
        public EducativeTitle EducativeTitle { get; set; }
    }
}
