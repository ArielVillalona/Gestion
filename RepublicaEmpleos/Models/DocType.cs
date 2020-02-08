using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class DocType
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProfileDocType> ProfileDocTypes { get; set; }
    }
}
