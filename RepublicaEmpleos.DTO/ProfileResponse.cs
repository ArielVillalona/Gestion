using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos.DTO
{
    public class ProfileResponse:Profile
    {
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
    }
}
