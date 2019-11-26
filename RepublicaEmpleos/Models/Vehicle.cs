using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Vehicle:DTO.Vehicle
    {
        public int TypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
