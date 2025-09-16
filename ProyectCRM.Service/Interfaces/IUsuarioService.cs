using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Interfaces
{
    public interface IUsuarioService : IServiceBase<UsuarioDTO, UsuarioRegisterDTO, Usuario>
    {
        Task<UsuarioDTO> RegisterUserAsync(UsuarioRegisterDTO dto);
        Task<bool> LoginAsync(UsuarioLoginDTO dto);

    }
}
