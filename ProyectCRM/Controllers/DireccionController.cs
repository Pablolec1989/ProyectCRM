using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.DireccionDTO;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class DireccionController : CustomControllerBase<DireccionDTO, DireccionCreateDTO, Direccion>
    {
        private readonly IDireccionService _service;

        public DireccionController(IDireccionService service)
            : base(service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public override async Task<ActionResult<DireccionDTO>> GetByIdAsync(Guid id)
        {
            var direccion = await _service.GetByIdWithTipoDireccionAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            return Ok(direccion);
        }
    }
}

