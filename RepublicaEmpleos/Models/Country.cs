using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Country
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
