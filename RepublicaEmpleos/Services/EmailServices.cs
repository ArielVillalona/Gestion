using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services
{
    public class EmailServices : IEmailServices<Email>
    {
        private readonly ApplicationDbContext _db;
        public EmailServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Email entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task<Email> Delete(int? Id)
        {
            return await _db.Emails
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.Id == Id);
        }
        public async Task DeletedConfirmed(Email entity)
        {
            _db.Emails.Remove(entity);
            await _db.SaveChangesAsync();
        }
        public async Task EditAsync(Email entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }
        public bool EmailExists(int id)
        {
            return _db.Emails.Any(e => e.Id == id);
        }
        public async Task<Email> FindByIdAsync(int? id)
        {
            return await _db.Emails.FindAsync(id);
        }
        public async Task<IEnumerable<Email>> GetAllByIdAsync(int? Id)
        {
            return await _db.Emails.Where(x => x.ProfileId == Id).ToListAsync();
        }

    }
}
