using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class VisitasController : CustomControllerBase<VisitaDTO, VisitaRequestDTO, Visita>
    {
        private readonly IVisitaService _service;

        public VisitasController(IVisitaService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<VisitaDetailDTO>> GetByIdVisitaCompletoAsync(Guid id)
        {
            var visitaDetail = await _service.GetVisitaCompletoByIdAsync(id);
            if (visitaDetail == null)
            {
                return NotFound();
            }
            return Ok(visitaDetail);
        }
    }
}
