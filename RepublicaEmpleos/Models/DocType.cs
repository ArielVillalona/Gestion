using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Models
{
    public class DocType:DTO.DocType
    {

        public DocType docType { get; set; }
        public Profile Profile { get; set; }

    }
}
