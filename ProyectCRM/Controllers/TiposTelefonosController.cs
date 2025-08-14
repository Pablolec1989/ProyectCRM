using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class TiposTelefonosController : CustomControllerBase<TipoTelefonoDTO, TipoTelefonoUpdateCreateDTO, TipoTelefono>
    {
        public TiposTelefonosController(ITipoTelefonoService service) : base(service)
        {
        }
    }
}
