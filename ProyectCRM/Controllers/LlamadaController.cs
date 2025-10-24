using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class LlamadaController : CustomControllerBase<LlamadaDTO, LlamadaRequestDTO, Llamado>
    {
        private readonly ILlamadoService _service;
        public LlamadaController(ILlamadoService service, IOutputCacheStore outputCacheStore) : base(service, outputCacheStore) 
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetByIdWithRelatedDataAsync(Guid id)
        {
            var llamadoDetail = await _service.GetLlamadaCompletoByIdAsync(id);
            if (llamadoDetail == null)
            {
                return NotFound();
            }
            return Ok(llamadoDetail);
        }
    }
}
