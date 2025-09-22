using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class TelefonoClienteController : CustomControllerBase<TelefonoDTO, TelefonoRequestDTO, Telefonos>
    {
        public TelefonoClienteController(ITelefonoService service) : base(service)
        {
        }
    }
}
