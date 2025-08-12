using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public interface IServiceBase<TDTO, TUpdateCreateDTO, TEntity> 
        where TDTO : class
        where TUpdateCreateDTO : class, new()
        where TEntity : EntityBase
    {
        Task<TDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> CreateAsync(TUpdateCreateDTO dto);
        Task<TDTO> UpdateAsync(Guid id, TUpdateCreateDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
