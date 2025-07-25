using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models;
using ProyectCRM.Service;
using ProyectCRM.Service.DTOs.AreaDTOs;

namespace ProyectCRM.Controllers
{
    [Route("api/area")]
    public class AreasController : CustomControllerBase<AreaDTO, Area>
    {
        public AreasController(IServiceBase<Area> serviceBase) : base(serviceBase)
        {
        }

    }
}
