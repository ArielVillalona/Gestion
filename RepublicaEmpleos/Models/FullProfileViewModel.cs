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
            Phone = new List<Phone>();
            Emails = new List<Email>();
            ProfileDocTypes = new List<ProfileDocType>();
            Vehicles = new List<Vehicle>();
        }
        public Task<DTO.ProfileResponse> profileResponse { get; set; }
        public List<Phone> Phone { get; set; }
        public List<Email> Emails { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public MatiralStatus MatiralStatus { get; set; }
        public EducativeTitle EducativeTitle { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<ProfileDocType> ProfileDocTypes { get; set; }
    }
}
