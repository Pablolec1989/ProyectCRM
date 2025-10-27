using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class VisitasController : CustomControllerBase<VisitaDTO, VisitaRequestDTO, Visita>
    {
        private readonly IVisitaService _service;
        private const string GetAllCacheTag = "VisitasCache";
        protected override string CacheTag => GetAllCacheTag;

        public VisitasController(IVisitaService service,
            ICacheCleaner cacheCleaner, 
            ILogger<Visita> logger) 
            : base(service, cacheCleaner, logger)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<VisitaDetailDTO>> GetByIdVisitaCompletoAsync(Guid id)
        {
            var visitaDetail = await _service.GetVisitaDetailAsync(id);
            if (visitaDetail == null)
            {
                return NotFound();
            }
            return Ok(visitaDetail);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<VisitaDTO>>> SearchByFilterAsync([FromQuery] VisitaFilterPaginated visitaFilterPaginated)
        {
            var visitas = await _service.SearchByFilterAsync(visitaFilterPaginated);
            if(visitas == null || !visitas.Any())
            {
                return NotFound();
            }
            return Ok(visitas);
        }
    }
}
