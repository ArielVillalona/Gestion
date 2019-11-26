using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Neighborhood:DTO.Neighborhood
    {
        public int SectorID { get; set; }
        public Sector Sector { get; set; }
    }
}
