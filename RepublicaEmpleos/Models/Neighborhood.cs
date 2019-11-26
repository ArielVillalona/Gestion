using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Neighborhood:DTO.Neighborhood
    {
        public virtual ICollection<Sector> Sector { get; set; }
    }
}
