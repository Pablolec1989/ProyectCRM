using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service
{
    public interface IServiceBase<TDTO, TRequestDTO, TEntity> 
        where TDTO : class
        where TRequestDTO : class, new()
        where TEntity : EntityBase
    {
        Task<TDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> CreateAsync(TRequestDTO dto);
        Task<TDTO> UpdateAsync(Guid id, TRequestDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
