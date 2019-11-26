using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class ProfileEmail
    {
        public int ProfileID { get; set; }
        public Profile Profile { get; set; }
        public int EmailID { get; set; }
        public Email Email { get; set; }
    }
}
