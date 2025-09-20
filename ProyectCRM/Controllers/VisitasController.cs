using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class VisitasController : CustomControllerBase<VisitaDTO, VisitaRequestDTO, Visita>
    {
        private readonly IVisitaService _service;

        public VisitasController(IVisitaService service) : base(service)
        {
            _service = service;
        }

        // GET: api/Visitas/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetVisitasByUsuarioAsync(Guid usuarioId)
        {
            var visitas = await _service.GetVisitasByUsuarioAsync(usuarioId);
            return Ok(visitas);
        }
    }
}
