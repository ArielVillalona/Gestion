using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual  ICollection<Vehicle> Vehicles { get; set; }
    }
}
