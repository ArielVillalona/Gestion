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
    public class VehicleServices:IGenericInterface<Vehicle>
    {
        private readonly ApplicationDbContext _dbContext;
        public VehicleServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Vehicle entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Vehicle> Delete(int? Id)
        {
            return await _dbContext.Vehicles
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.Id == Id);
        }
        public async Task DeletedConfirmed(Vehicle Entity)
        {
            Entity.VehicleType = null;
            _dbContext.Vehicles.Remove(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Vehicle entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _dbContext.Vehicles.Any(e => e.Id == id);
        }

        public async Task<Vehicle> FindByIdAsync(int? id)
        {
            return await _dbContext.Vehicles
                .Include(x => x.VehicleType)
                .FirstAsync(g => g.Id == id);
        }

        public async Task<List<Vehicle>> GetAllById(int? Id)
        {
            var ProDocType = await _dbContext.Vehicles
                .Include(x => x.VehicleType)
                .Where(x => x.ProfileId == Id)
                .ToListAsync();
            return ProDocType;
        }
    }
}
