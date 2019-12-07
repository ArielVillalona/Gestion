using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class ProfileDocType:DTO.ProfileDocType
    {
        public ICollection<DocType> DocTypes { get; set; }
    }
}
