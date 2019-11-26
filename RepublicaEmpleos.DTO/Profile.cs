using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaEmpleos.DTO
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Objetiv { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HeadHome { get; set; }
        public string ImagePath { get; set; }
        public int? IdGender { get; set; }
        public int? IdNationatily { get; set; }
        public int? IdMatiralstatus { get; set; }
        public int? IdEducatibleTitle { get; set; }

    }
}
