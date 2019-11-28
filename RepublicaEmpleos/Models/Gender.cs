using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Gender:DTO.Gender
    {
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
