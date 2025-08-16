using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class UsuariosController : CustomControllerBase<UsuarioDTO, UsuarioUpdateCreateDTO, Usuario>
    {
        public UsuariosController(IUsuarioService service) : base(service)
        {
        }
    }
}
