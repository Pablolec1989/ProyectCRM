using ProyectCRM.Models.Entities;
using ProyectCRM.Service;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class AreasController : CustomControllerBase<AreaDTO, AreaUpdateCreateDTO, Area>
    {
        public AreasController(IAreaService service)
            : base(service)
        {
        }

    }
}
