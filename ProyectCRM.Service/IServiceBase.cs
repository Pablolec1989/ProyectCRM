using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public interface IServiceBase<TDTO, TCreateDTO, TEntity> 
        where TDTO : class
        where TCreateDTO : class, new()
        where TEntity : EntityBase
    {
        Task<TDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> CreateAsync(TCreateDTO dto);
        Task<TDTO> UpdateAsync(Guid id, TDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
