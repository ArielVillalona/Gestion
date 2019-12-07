using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos.DTO
{
    public class AddressResponse:Address
    {
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; } = new List<Neighborhood>();
    }
}
