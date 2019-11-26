using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Profile : DTO.Profile
    {
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public MatiralStatus MatiralStatus { get; set; }
        public EducativeTitle EducativeTitle { get; set; }

        public virtual ICollection<ProfileAddress> ProfileAddresses { get; set; } = new List<ProfileAddress>();
        public virtual ICollection<ProfileEmail> ProfileEmails { get; set; } = new List<ProfileEmail>();
        public virtual ICollection<ProfilePhone> ProfilePhones { get; set; } = new List<ProfilePhone>();
        public virtual ICollection<ProfileVehicle> ProfileVehicles { get; set; } = new List<ProfileVehicle>();
    }
}
