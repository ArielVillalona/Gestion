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
        public int? GenderId { get; set; }
        public int? NationalityId { get; set; }
        public int? MatiralStatusId { get; set; }
        public int? EducativeTitleId { get; set; }

    }
}
