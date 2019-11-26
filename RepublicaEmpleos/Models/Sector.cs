using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Sector:DTO.Sector
    {
        public int CityID { get; set; }
        public City City { get; set; }
    }
}
