using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class TelefonoClienteController : CustomControllerBase<TelefonoClienteDTO, TelefonoClienteRequestDTO, TelefonosCliente>
    {
        public TelefonoClienteController(ITelefonoClienteService service) : base(service)
        {
        }
    }
}
