using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos.DTO
{
    public class ProfileResponse:Profile
    {
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
        public virtual ICollection<Email> ProfileEmails { get; set; } = new List<Email>();
        public virtual ICollection<Vehicle> ProfileVehicles { get; set; } = new List<Vehicle>();
        public virtual ICollection<ProfileDocType> ProfileDocTypes { get; set; } = new List<ProfileDocType>();
    }
}
