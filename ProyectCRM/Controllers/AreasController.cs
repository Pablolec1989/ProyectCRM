using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class AreasController : CustomControllerBase<AreaDTO, AreaRequestDTO, Area>
    {
        private readonly IAreaService _service;
        public AreasController(IAreaService service)
            : base(service)
        {
            _service = service;
        }
    }
}
