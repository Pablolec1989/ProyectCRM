using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class RubrosController : CustomControllerBase<RubroDTO, RubroRequestDTO, Rubro>
    {
        public RubrosController(IRubroService service) : base(service)
        {
        }
    }
}
