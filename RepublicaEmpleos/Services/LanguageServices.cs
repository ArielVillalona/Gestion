using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Models;
using RepublicaEmpleos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services
{
    public class LanguageServices : ILanguajeServices<ProfileLanguage>
    {
        private readonly ApplicationDbContext _db;

        public LanguageServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(ProfileLanguage entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ProfileLanguage> Delete(int ProfId, int langId)
        {
            return await _db.ProfileLanguages
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.LanguageId == langId && m.ProfileId == ProfId);
        }

        public async Task DeletedConfirmed(ProfileLanguage Entity)
        {
            _db.ProfileLanguages.Remove(Entity);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(ProfileLanguage entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }

        public bool Exists(int langid, int profid)
        {
            return _db.ProfileLanguages.Any(e => e.LanguageId == langid && e.ProfileId==profid);
        }

        public async Task<ProfileLanguage> FindByIdAsync(int ProfId, int langId)
        {
            return await _db.ProfileLanguages.FirstOrDefaultAsync(x=>x.ProfileId == ProfId && x.LanguageId == langId);
        }

        public async Task<List<ProfileLanguage>> GetAllById(int? Id)
        {
            return await _db.ProfileLanguages.Where(x => x.ProfileId == Id).ToListAsync();
        }
    }
}
