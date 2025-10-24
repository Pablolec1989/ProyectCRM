using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.Service.Services;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Utils;
using System.Linq.Expressions;

namespace ProyectCRM.Models.Controllers
{
    public class EmpresaController : CustomControllerBase<EmpresaDTO, EmpresaRequestDTO, Empresa>
    {
        private readonly IEmpresaService _service;

        public EmpresaController(IEmpresaService service, IOutputCacheStore outputCacheStore) : base(service, outputCacheStore)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<EmpresaDetailDTO>> GetEmpresaDetailAsync(Guid id)
        {
            var empresaDetail = await _service.GetEmpresaDetailDTOAsync(id);
            if (empresaDetail == null)
            {
                return NotFound($"La empresa con Id {id} no fue encontrada.");
            }
            return Ok(empresaDetail);
        }

        [HttpGet("paged")]
        public async Task<ActionResult> GetAll([FromQuery] PaginationDTO pagination)
        {
            var result = await _service.SearchPaginatedAsync(pagination);

            if (result == null || !result.Any())
            {
                return NotFound("No se encontraron empresas.");
            }
            return Ok(result);
        }

    }
}
