using ProyectCRM.Models.Entities;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class AsuntoDeContactoController : CustomControllerBase<Service.DTOs.AsuntoDeContactoDTO, AsuntoDeContactoUpdateCreateDTO, Models.Entities.AsuntoDeContacto>
    {
        public AsuntoDeContactoController(IAsuntoDeContactoService service) : base(service)
        {
        }
    }
}
