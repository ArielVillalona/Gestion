using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class EducativeTitle
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
