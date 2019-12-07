using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services.Interfaces
{
    public interface IProfileServices
    {
        Task<IEnumerable<Profile>> GetProfiles();
        Task UpdateProfileAsync(Profile profile);
        Task CreateProfileAsync(Profile profile);
        Task<DTO.ProfileResponse> GetProfileById(string Id);
    }
}
