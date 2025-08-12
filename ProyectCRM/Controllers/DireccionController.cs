using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.DireccionDTO;
using ProyectCRM.Service.DTOs.DireccionDTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class DireccionController : CustomControllerBase<DireccionDTO, DireccionCreateUpdateDTO, Direccion>
    {
        private readonly IDireccionService _service;

        public DireccionController(IDireccionService service)
            : base(service)
        {
            _service = service;
        }
    }
}

