using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Vehicle:DTO.Vehicle
    {
        public VehicleType VehicleType { get; set; }

        public virtual ICollection<ProfileVehicle> ProfileVehicles { get; set; }
    }
}
