using Microsoft.AspNetCore.Identity;
using RepublicaEmpleos.Models;
using RepublicaEmpleos.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepublicaEmpleos
{
    public class Profile : DTO.Profile
    {
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public MatiralStatus MatiralStatus { get; set; }
        public EducativeTitle EducativeTitle { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<ProfileAddress> ProfileAddresses { get; set; } = new List<ProfileAddress>();
        public virtual ICollection<ProfileEmail> ProfileEmails { get; set; } = new List<ProfileEmail>();
        public virtual ICollection<ProfilePhone> ProfilePhones { get; set; } = new List<ProfilePhone>();
        public virtual ICollection<ProfileVehicle> ProfileVehicles { get; set; } = new List<ProfileVehicle>();
        public virtual ICollection<ProfileDocType> ProfileDocTypes { get; set; } = new List<ProfileDocType>();
    }
}
