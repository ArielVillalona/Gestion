using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Country:DTO.Country
    {
        public virtual ICollection<City> Cities { get; set; }
    }
}
