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
    public interface IUsuarioService : IServiceBase<UsuarioDTO, UsuarioRequestDTO, Usuario>
    {
        Task<UsuarioDetailDTO> GetUserDetailAsync(Guid id);
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<IEnumerable<UsuarioDTO>> SearchByFilterAsync(UsuarioFilterDTO filterDTO);
    }
}
