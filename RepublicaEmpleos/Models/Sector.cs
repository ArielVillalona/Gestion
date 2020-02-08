using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Sector
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CityID { get; set; }
        public City City { get; set; }
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
