using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class MatiralStatus:DTO.MatiralStatus
    {
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
