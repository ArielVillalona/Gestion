using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepublicaEmpleos
{
    public class Email
    {
        public int Id { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Description { get; set; }
        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }

    }
}
