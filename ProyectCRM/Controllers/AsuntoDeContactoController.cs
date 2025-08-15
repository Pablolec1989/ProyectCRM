using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class AsuntoDeContactoController : CustomControllerBase<Service.DTOs.AsuntoDeContactoDTO, AsuntoDeContactoUpdateCreateDTO, AsuntoDeContacto>
    {
        public AsuntoDeContactoController(IAsuntoDeContactoService service) : base(service)
        {
        }
    }
}
