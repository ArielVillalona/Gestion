using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Nationality:DTO.Nationality
    {
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
