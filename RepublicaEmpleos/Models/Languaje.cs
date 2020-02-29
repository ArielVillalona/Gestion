using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class Languaje
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
