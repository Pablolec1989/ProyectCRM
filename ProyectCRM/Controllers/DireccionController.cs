using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class DireccionController : CustomControllerBase<DireccionDTO, DireccionRequestDTO, Direccion>
    {
        private readonly IDireccionService _service;

        public DireccionController(IDireccionService service)
            : base(service)
        {
            _service = service;
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<DireccionDetailDTO>> GetDireccionWithDetailsAsync(Guid id)
        {
            var direccionDetail = await _service.GetDireccionWithDetailsAsync(id);
            if (direccionDetail == null)
                return NotFound();
            return Ok(direccionDetail);
        }

    }
}

