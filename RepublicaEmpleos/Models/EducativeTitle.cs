using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class EducativeTitle:DTO.EducativeTitle
    {
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
