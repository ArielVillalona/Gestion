using RepublicaEmpleos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services.Interfaces
{
    public interface IProfileServices
    {
        Task<IEnumerable<Profile>> GetProfiles();
        Task UpdateProfileAsync(FullProfileViewModel profile);
        Task CreateProfileAsync(FullProfileViewModel profile);
        Task<FullProfileViewModel> GetProfileById(string Id);
    }
}
