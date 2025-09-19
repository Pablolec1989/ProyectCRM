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
        Task<Usuario> GetUserAsync(string usuario);

    }
}
