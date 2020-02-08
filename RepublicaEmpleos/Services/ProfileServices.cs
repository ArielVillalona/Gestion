using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Infrastructure;
using RepublicaEmpleos.Models;
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
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        FullProfileViewModel FPVM = new FullProfileViewModel();
        public ProfileServices(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task CreateProfileAsync(FullProfileViewModel profile)
        {   
            _db.Profiles.Add(_mapper.Map<Profile>(profile));
            await _db.SaveChangesAsync();
        }
        public async Task<FullProfileViewModel> GetProfileById(string Id)
        {
            var prof = await _db.Profiles
                        .Include(s => s.ProfileAddresses)
                            .ThenInclude(z => z.Address)
                        .Include(x => x.Phones)
                        .Include(x=>x.ProfileVehicles)
                            .ThenInclude(x=>x.VehicleType)
                        .Include(x=>x.ProfileEmails)
                        .Include(x=>x.ProfileDocTypes)
                            .ThenInclude(z => z.DocType)
                        .SingleOrDefaultAsync(x=>x.ApplicationUserId==Id);
            FPVM = _mapper.Map<FullProfileViewModel>(prof);
            return FPVM;
        }
        public Task<IEnumerable<Profile>> GetProfiles()
        {
            throw new NotImplementedException();
        }
        public async Task UpdateProfileAsync(FullProfileViewModel profile)
        {
            _db.Profiles.Update(_mapper.Map<Profile>(profile));
            await _db.SaveChangesAsync();
        }
    }
}
