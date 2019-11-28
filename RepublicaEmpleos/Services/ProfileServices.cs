using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Models.Identity;
using RepublicaEmpleos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services
{
    public class ProfileServices : IProfileServices
    {
        private readonly ApplicationDbContext _db;
        public ProfileServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateProfileAsync(Profile profile)
        {
            _db.Profiles.Add(profile);
            await _db.SaveChangesAsync();
        }
        public Profile GetProfileById(string Id)
        {
            return _db.Profiles.Where(x => x.ApplicationUserId == Id).FirstOrDefault();
        }
        public Task<IEnumerable<Profile>> GetProfiles()
        {
            throw new NotImplementedException();
        }
        public async Task UpdateProfileAsync(Profile profile)
        {
            _db.Profiles.Update(profile);
            await _db.SaveChangesAsync();
        }
    }
}
