using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos.DTO
{
    public class Sector
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int? CityID { get; set; }

    }
}
