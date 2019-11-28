using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class ProfileDocType
    {
        public int DocTypeID { get; set; }
        public DocType DocType { get; set; }

        public int ProfileID { get; set; }
        public Profile Profile { get; set; }
    }
}
