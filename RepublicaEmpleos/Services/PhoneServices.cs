using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services
{
    public class PhoneServices : IPhoneServices<Phone>
    {
        private readonly ApplicationDbContext _db;
        public PhoneServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Phone entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task<Phone> Delete(int? Id)
        {
            return await _db.Phones
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.Id == Id);
        }
        public async Task DeletedConfirmed(Phone entity)
        {
            _db.Phones.Remove(entity);
            await _db.SaveChangesAsync();
        }
        public async Task EditAsync(Phone entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task<Phone> FindByIdAsync(int? id)
        {
            return await _db.Phones.FindAsync(id);
        }
        public IEnumerable<Phone> GetAllById(int Id)
        {
            return _db.Phones.Where(x => x.ProfileId == Id).ToList();
        }
        bool IPhoneServices<Phone>.PhoneExists(int id)
        {
            return _db.Phones.Any(e => e.Id == id);
        }
    }
}
