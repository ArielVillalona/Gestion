using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Email:DTO.Email
    {
        public Profile Profile { get; set; }

    }
}
