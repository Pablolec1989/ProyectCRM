using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class TelefonosController : CustomControllerBase<TelefonoDTO, TelefonoRequestDTO, Telefono>
    {
        public TelefonosController(ITelefonoService service) : base(service)
        {
        }
    }
}
