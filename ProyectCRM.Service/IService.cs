using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public interface IService<TCreateUpdateDTO, TDTO>
        where TCreateUpdateDTO : class
        where TDTO : class
    {
        Task<TDTO> GetByIdAsync(int id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> CreateAsync(TCreateUpdateDTO createDto);
        Task<TDTO> UpdateAsync(int id, TCreateUpdateDTO updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
