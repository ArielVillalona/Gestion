using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class City:DTO.City
    {
        public virtual ICollection<Country> Country { get; set; }
    }
}
