using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Phone
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }
        
    }
}
