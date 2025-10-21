using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class EmpresaController : CustomControllerBase<EmpresaDTO, EmpresaRequestDTO, Empresa>
    {
        private readonly IEmpresaService _service;
        public EmpresaController(IEmpresaService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<EmpresaDetailDTO>> GetEmpresaCompletoByIdAsync(Guid id)
        {
            var empresaDetail = await _service.GetEmpresaDetailDTOAsync(id);
            if (empresaDetail == null)
            {
                return NotFound($"La empresa con Id {id} no fue encontrada.");
            }
            return Ok(empresaDetail);
        }

        [HttpGet("search/{params}")]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetEmpresasByFilterAsync([FromQuery] string? razonSocial, [FromQuery] string? cuit)
        {
            return Ok(await _service.GetAsync());

        }
    }
}
