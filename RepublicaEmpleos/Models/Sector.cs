using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Sector:DTO.Sector
    {
        public virtual ICollection<City> City { get; set; }
    }
}
