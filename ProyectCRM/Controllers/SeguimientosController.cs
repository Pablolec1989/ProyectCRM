using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class SeguimientosController : CustomControllerBase<SeguimientoDTO, SeguimientoRequestDTO, Seguimiento>
    {
        private readonly ISeguimientoService _service;
        public SeguimientosController(ISeguimientoService service, IOutputCacheStore outputCacheStore, ILogger<Seguimiento> logger) 
            : base(service, outputCacheStore, logger)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetSeguimientoWithDetailsAsync(Guid id)
        {
            var seguimientoDetail = await _service.GetSeguimientoCompletoByIdAsync(id);
            if (seguimientoDetail == null)
            {
                return NotFound();
            }
            return Ok(seguimientoDetail);
        }
    }
}
