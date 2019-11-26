using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class ProfileAddress
    {
        public int ProfileID { get; set; }
        public Profile Profile { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
    }
}
