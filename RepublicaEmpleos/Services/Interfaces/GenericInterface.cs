using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services.Interfaces
{
    public interface IGenericInterface<T>
    {
        Task<List<T>> GetAllById(int? Id);
        Task CreateAsync(T entity);
        Task<T> FindByIdAsync(int? id);
        Task EditAsync(T entity);
        Task<T> Delete(int? Id);
        Task DeletedConfirmed(T Entity);
        bool Exists(int id);
    }
}
