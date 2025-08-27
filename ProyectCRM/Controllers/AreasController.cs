using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class AreasController : CustomControllerBase<AreaDTO, AreaRequestDTO, Area>
    {
        public AreasController(IAreaService service)
            : base(service)
        {
        }

    }
}
