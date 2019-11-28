using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Sector : DTO.Sector
    {
        public City City { get; set; }
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
