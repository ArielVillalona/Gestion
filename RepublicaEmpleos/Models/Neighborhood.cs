using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Neighborhood:DTO.Neighborhood
    {
        public Sector Sector { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
