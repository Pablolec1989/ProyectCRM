using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class CondicionIvaController : CustomControllerBase<CondicionIvaDTO, CondicionIvaRequestDTO, CondicionIva>
    {
        public CondicionIvaController(ICondicionIvaService service) : base(service)
        {
        }
    }
}
