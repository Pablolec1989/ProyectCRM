using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class RubrosController : CustomControllerBase<RubroDTO, RubroRequestDTO, Rubro>
    {
        public RubrosController(IRubroService service) : base(service)
        {
        }
    }
}
