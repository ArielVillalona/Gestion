using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos.DTO
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string references { get; set; }
        public int? NeighborhoodID { get; set; }
    }
}
