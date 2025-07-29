using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class AreasController : CustomControllerBase<AreaDTO, Area>, IAreaController
    {
        public AreasController(IServiceBase<AreaDTO, Area> serviceBase) : base(serviceBase) { }
    }
}
