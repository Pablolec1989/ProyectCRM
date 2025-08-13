using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AsuntoDeContactoDTO;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class AsuntoDeContactoController : CustomControllerBase<Service.DTOs.AsuntoDeContactoDTO.AsuntoDeContactoDTO, AsuntoDeContactoUpdateCreateDTO, Models.Entities.AsuntoDeContacto>
    {
        public AsuntoDeContactoController(IAsuntoDeContactoService service) : base(service)
        {
        }
    }
}
