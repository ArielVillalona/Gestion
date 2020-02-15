using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RepublicaEmpleos.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Nombre De Usuario")]
        [RegularExpression(pattern: "/[^a-zA-Z0-9]/",ErrorMessage ="El {0} solo acepta Caracteres alphanumericos")]
        public string FullName { get; set; }

        [PersonalData]
        public string JobDescription { get; set; }

        [PersonalData]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BirthDate { get; set; }
        public Profile Profile { get; set; }
    }
}
