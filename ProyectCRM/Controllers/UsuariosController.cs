using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class UsuariosController : CustomControllerBase<UsuarioDTO, UsuarioRequestDTO, Usuario>
    {
        public UsuariosController(IUsuarioService service) : base(service)
        {
        }
    }
}
