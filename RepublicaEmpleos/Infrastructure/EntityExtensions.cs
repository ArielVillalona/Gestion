using RepublicaEmpleos.Models;
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
                ProfileVehicles = profile.ProfileVehicles?
                    .Select(x =>
                    new DTO.Vehicle {
                        Id = x.Id,
                        ProfileId = x.ProfileId,
                        Matricula = x.Matricula,
                        VehicleTypeId=x.VehicleType.Id
                    })
                .ToList(),
                ProfileEmails = profile.ProfileEmails?
                    .Select(x =>
                        new DTO.Email
                        {
                            Description = x.Description,
                            Id = x.Id,
                            ProfileId = x.ProfileId
                        })
                .ToList(),
                Phones = profile.Phones?
                    .Select(x=> 
                        new DTO.Phone 
                        {
                            Id = x.Id, 
                            Description = x.Description, 
                            ProfileId = x.ProfileId
                        }).ToList(),
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
                ProfileDocTypes = profile.ProfileDocTypes?
                    .Select(x=>
                        new DTO.ProfileDocType{ 
                            ProfileID = x.ProfileID,
                            DocTypeID = x.DocTypeID,
                            NumberDocument = x.NumberDocument
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
                ApplicationUserId = profile.ApplicationUserId,
            };
    }
}
