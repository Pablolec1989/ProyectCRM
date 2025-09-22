using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class SeguimientosController : CustomControllerBase<SeguimientoDTO, SeguimientoRequestDTO, Seguimiento>
    {
        private readonly ISeguimientoService _service;
        public SeguimientosController(ISeguimientoService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetSeguimientoWithDetailsAsync(Guid id)
        {
            var seguimientoDetail = await _service.GetSeguimientoWithDetailsAsync(id);
            if (seguimientoDetail == null)
            {
                return NotFound();
            }
            return Ok(seguimientoDetail);
        }
    }
}
