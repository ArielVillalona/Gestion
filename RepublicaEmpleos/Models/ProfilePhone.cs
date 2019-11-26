using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class ProfilePhone
    {
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
