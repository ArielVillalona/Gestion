using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RepublicaEmpleos.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public string JobDescription { get; set; }

        [PersonalData]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BirthDate { get; set; }
        public Profile Profile { get; set; }
    }
}
