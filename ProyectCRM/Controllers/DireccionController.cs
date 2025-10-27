using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using Microsoft.AspNetCore.OutputCaching;

namespace ProyectCRM.Models.Controllers
{
    public class DireccionController : CustomControllerBase<DireccionDTO, DireccionRequestDTO, Direccion>
    {
        private readonly IDireccionService _service;

        public DireccionController(IDireccionService service, 
            IOutputCacheStore outputCacheStore, 
            ILogger<Direccion> logger)
            : base(service, outputCacheStore, logger)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<DireccionDetailDTO>> GetDireccionWithDetailsAsync(Guid id)
        {
            var direccionDetail = await _service.GetDireccionCompletoByIdAsync(id);
            if (direccionDetail == null)
                return NotFound();
            return Ok(direccionDetail);
        }

    }
}

