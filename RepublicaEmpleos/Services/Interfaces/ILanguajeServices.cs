using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Services.Interfaces
{
    public interface ILanguajeServices<T>
    {
        Task<List<T>> GetAllById(int? Id);
        Task CreateAsync(T entity);
        Task<T> FindByIdAsync(int ProfId, int langId);
        Task EditAsync(T entity);
        Task<T> Delete(int ProfId, int langId);
        Task DeletedConfirmed(T Entity);
        bool Exists(int langid, int profid);
    }
}
