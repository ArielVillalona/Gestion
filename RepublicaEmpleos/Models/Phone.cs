using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Phone:DTO.Phone
    {
        public virtual ICollection<ProfilePhone> ProfilePhones { get; set; }
        
    }
}
