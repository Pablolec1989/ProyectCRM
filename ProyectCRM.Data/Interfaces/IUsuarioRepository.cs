using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<bool> GetUsuarioByNombreYApellidoAsync(string nombre, string apellido);
        Task<Usuario> GetUserDetailAsync(Guid id);
        Task<Usuario> GetUserByApellidoAsync(string apellido);
        Task<List<Guid>> GetExistingsUserIdsAsync(IEnumerable<Guid> userIds);
        Task<IEnumerable<Usuario>> SearchByFilterAsync(UsuarioFilterPaginated filterDTO);
    }
}
