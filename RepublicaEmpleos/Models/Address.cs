using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Address:DTO.Address
    {
        public int NeighborhoodID { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
