using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Address:DTO.Address
    {
        public virtual ICollection<Neighborhood> Neighborhood { get; set; }
        public virtual ICollection<ProfileAddress> ProfileAddresses { get; set; }
    }
}
