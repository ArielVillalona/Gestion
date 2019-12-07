using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos.DTO
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Matricula { get; set; }

        public int ProfileId { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
