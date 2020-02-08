using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Matricula { get; set; }

        public int ProfileId { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public Profile Profile { get; set; }
    }
}
