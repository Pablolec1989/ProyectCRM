using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class TelefonosClientesController : CustomControllerBase<TelefonoClienteDTO, TelefonoClienteUpdateCreateDTO, TelefonoCliente>
    {
        public TelefonosClientesController(ITelefonoClienteService service) : base(service)
        {
        }
    }
}
