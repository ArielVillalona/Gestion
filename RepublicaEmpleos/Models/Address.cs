using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string referenc { get; set; }
        public int? NeighborhoodID { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public virtual ICollection<ProfileAddress> ProfileAddresses { get; set; }
    }
}
