using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos
{
    public class Profile:DTO.Profile
    {
        public int IdGender { get; set; }
        public Gender Gender { get; set; }
        public int IdNationatily { get; set; }
        public Nationality Nationality { get; set; }
        public int IdMatiralstatus { get; set; }
        public MatiralStatus MatiralStatus { get; set; }
        public int IdEducatibleTitle { get; set; }
        public EducativeTitle EducativeTitle { get; set; }
    }
}
