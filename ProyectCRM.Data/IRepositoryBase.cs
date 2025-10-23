using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data
{
    public interface IRepositoryBase<T> 
    where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> SearchPaginated(PaginationDTO pagination);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> EntityExistsAsync(Guid id);
    }
}
