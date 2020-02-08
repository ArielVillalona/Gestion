using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class MatiralStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
