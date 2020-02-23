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
    public class DocTypeServices : IGenericInterface<ProfileDocType>
    {
        private readonly ApplicationDbContext _dbContext;
        public DocTypeServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(ProfileDocType entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<ProfileDocType> Delete(int? Id)
        {
            return await _dbContext.ProfileDocType
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.DocTypeID == Id);
        }
        public async Task DeletedConfirmed(ProfileDocType Entity)
        {
            _dbContext.ProfileDocType.Remove(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(ProfileDocType entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _dbContext.ProfileDocType.Any(e => e.DocTypeID == id);
        }

        public async Task<ProfileDocType> FindByIdAsync(int? id)
        {
            return await _dbContext.ProfileDocType
                .Include(x => x.DocType)
                .FirstAsync(g => g.DocTypeID == id);
        }

        public async Task<List<ProfileDocType>> GetAllById(int? Id)
        {
            var ProDocType = await _dbContext.ProfileDocType
                .Include(x => x.DocType)
                .Where(x => x.ProfileID == Id)
                .ToListAsync();
            return ProDocType;
        }
    }
}
