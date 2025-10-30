using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data
{
    public interface IRepositoryBase<FilterPaginatedDTO, TEntity>
        where TEntity : class
        where FilterPaginatedDTO : class
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> SearchPaginatedAsync(FilterPaginatedDTO filterPaginatedDTO);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> EntityExistsAsync(Guid id);
    }
}
