using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AsuntoDeContactoDTO;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class AsuntoDeContactoController : CustomControllerBase<AsuntoDeContactoDTO, AsuntoDeContactoCreateDTO, AsuntoDeContacto>
    {
        public AsuntoDeContactoController(IAsuntoDeContactoService service) : base(service)
        {
        }
    }
}
