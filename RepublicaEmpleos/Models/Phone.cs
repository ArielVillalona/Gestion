using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Phone:DTO.Phone
    {
        public Profile Profile { get; set; }
        
    }
}
