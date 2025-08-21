using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class TelefonosClientesController : CustomControllerBase<TelefonoClienteDTO, TelefonoClienteRequestDTO, TelefonoCliente>
    {
        public TelefonosClientesController(ITelefonoClienteService service) : base(service)
        {
        }
    }
}
