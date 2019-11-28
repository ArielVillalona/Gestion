using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services.Interfaces
{
    public interface IProfileServices
    {
        Task<IEnumerable<Profile>> GetProfiles();
        Profile GetProfileById(string Id);
        Task UpdateProfileAsync(Profile profile);
        Task CreateProfileAsync(Profile profile);
    }
}
