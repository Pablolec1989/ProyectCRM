using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service
{
    public interface IServiceBase<TDTO, TRequestDTO, FilterPaginatedDTO, TEntity> 
        where TDTO : class
        where TRequestDTO : class, new()
        where FilterPaginatedDTO : class
        where TEntity : EntityBase
    {
        Task<TDTO> GetByIdAsync(Guid Id);
        Task<IEnumerable<TDTO>> SearchPaginatedAsync(FilterPaginatedDTO filterPaginatedDTO);
        Task<TDTO> CreateAsync(TRequestDTO dto);
        Task<TDTO> UpdateAsync(Guid Id, TRequestDTO dto);
        Task<bool> DeleteAsync(Guid Id);
    }
}
