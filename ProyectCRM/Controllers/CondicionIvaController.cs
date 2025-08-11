using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.IvaCondicionDTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class CondicionIvaController : CustomControllerBase<CondicionIvaDTO, CondicionIvaCreateDTO, CondicionIva>
    {
        public CondicionIvaController(ICondicionIvaService service) : base(service)
        {
        }
    }
}
