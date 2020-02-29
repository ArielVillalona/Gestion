using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class ProfileLanguage
    {
        [Required]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        [Required]
        public int LanguageId { get; set; }
        public Languaje Language { get; set; }
        [Required]
        public int Spoken { get; set; }
        [Required]
        public int Written { get; set; }
        [Required]
        public int Reading { get; set; }
    }
}
