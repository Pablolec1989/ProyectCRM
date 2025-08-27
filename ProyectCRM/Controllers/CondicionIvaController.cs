using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class CondicionIvaController : CustomControllerBase<CondicionIvaDTO, CondicionIvaRequestDTO, CondicionIva>
    {
        public CondicionIvaController(ICondicionIvaService service) : base(service)
        {
        }
    }
}
