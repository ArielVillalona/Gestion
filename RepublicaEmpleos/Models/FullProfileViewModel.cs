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
        }
        public Profile Profile { get; set; }
        public List<Phone> Phone { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public MatiralStatus MatiralStatus { get; set; }
        public EducativeTitle EducativeTitle { get; set; }
    }
}
