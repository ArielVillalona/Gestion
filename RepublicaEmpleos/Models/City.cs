using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class City:DTO.City
    {
        public Country Country { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
