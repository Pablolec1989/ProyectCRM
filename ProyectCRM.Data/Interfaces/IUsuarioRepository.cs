using ProyectCRM.Models.Entities;
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
        Task<List<Guid>> GetExistingUserIdsAsync(List<Guid> ids);
        Task<Usuario> GetUsuarioCompletoByIdAsync(Guid id);
    }
}
