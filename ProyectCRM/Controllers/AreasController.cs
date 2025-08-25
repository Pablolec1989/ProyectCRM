using ProyectCRM.Models.Entities;
using ProyectCRM.Service;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class AreasController : CustomControllerBase<AreaDTO, AreaRequestDTO, Area>
    {
        public AreasController(IAreaService service)
            : base(service)
        {
        }

    }
}
