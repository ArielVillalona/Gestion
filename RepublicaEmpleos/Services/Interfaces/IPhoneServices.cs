using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services.Interfaces
{
    public interface IPhoneServices<T>
    {
        IEnumerable<T> GetAllById(int Id);
        Task CreateAsync(T entity);
        Task<T> FindByIdAsync(int? id);
        IQueryable<T> FindByPhoneAsync(string Number, int id);
        Task EditAsync(T entity);
        Task<T> Delete(int? Id);
        Task DeletedConfirmed(T Entity);
        bool PhoneExists(int id);
    }
}
