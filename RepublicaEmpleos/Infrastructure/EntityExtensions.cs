using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Infrastructure
{
    public static class EntityExtensions
    {
        public static DTO.ProfileResponse MapProfile(this Profile profile) =>
            new DTO.ProfileResponse
            {
                Id = profile.Id,
                Phones = profile.Phones?.Select(x=> new DTO.Phone {Id = x.Id, Description = x.Description, ProfileId = x.ProfileId}).ToList(),
                Addresses = profile.ProfileAddresses?
                    .Select(PA =>
                        new DTO.Address
                        {
                            Id = PA.AddressID,
                            Building = PA.Address.Building,
                            referenc = PA.Address.referenc,
                            Street = PA.Address.Street,
                            NeighborhoodID = PA.Address.NeighborhoodID
                        })
                .ToList(),
                DateOfBirth = profile.DateOfBirth,
                GenderId = profile.GenderId,
                EducativeTitleId = profile.EducativeTitleId,
                LastName = profile.LastName,
                Name = profile.Name,
                Objetiv=profile.Objetiv,
                HeadHome = profile.HeadHome,
                MatiralStatusId=profile.MatiralStatusId,
                NationalityId = profile.NationalityId,
                ImagePath = profile.ImagePath,
                ApplicationUserId = profile.ApplicationUserId
            };
    }
}
