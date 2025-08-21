using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class DireccionController : CustomControllerBase<DireccionDTO, DireccionRequestDTO, Direccion>
    {
        private readonly IDireccionService _service;

        public DireccionController(IDireccionService service)
            : base(service)
        {
            _service = service;
        }
    }
}

