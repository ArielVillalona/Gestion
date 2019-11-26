using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class City:DTO.City
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
