using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class City
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
