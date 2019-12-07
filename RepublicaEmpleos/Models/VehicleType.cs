using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class VehicleType:DTO.VehicleType
    {
        public virtual  ICollection<Vehicle> Vehicles { get; set; }
    }
}
