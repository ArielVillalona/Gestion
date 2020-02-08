using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? SectorID { get; set; }
        public Sector Sector { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
