using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.RubroDTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class RubrosController : CustomControllerBase<RubroDTO, RubroCreateDTO, Rubro>
    {
        public RubrosController(IRubroService service) : base(service)
        {
        }
    }
}
