using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class FullProfileViewModel
    {
        public FullProfileViewModel()
        {
            ProfileAddresses = new List<ProfileAddress>();
            ProfileEmails = new List<Email>();
            Phones = new List<Phone>();
            ProfileVehicles = new List<Vehicle>();
            ProfileDocTypes = new List<ProfileDocType>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Objetiv { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HeadHome { get; set; }
        public string ImagePath { get; set; }
        public int? GenderId { get; set; }
        public int? NationalityId { get; set; }
        public int? MatiralStatusId { get; set; }
        public int? EducativeTitleId { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ICollection<ProfileAddress> ProfileAddresses { get; set; } = new List<ProfileAddress>();
        public virtual ICollection<Email> ProfileEmails { get; set; } = new List<Email>();
        public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
        public virtual ICollection<Vehicle> ProfileVehicles { get; set; } = new List<Vehicle>();
        public virtual ICollection<ProfileDocType> ProfileDocTypes { get; set; } = new List<ProfileDocType>();
    }
}
