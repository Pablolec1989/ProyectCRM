using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public interface IServiceBase<TDTO, TEntity> 
        where TDTO : class
        where TEntity : class
    {
        Task<TDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> CreateAsync(TDTO dto);
        Task<TDTO> UpdateAsync(Guid id, TDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
