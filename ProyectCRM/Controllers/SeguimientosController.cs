using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace ProyectCRM.Models.Controllers
{
    public class SeguimientosController : CustomControllerBase<SeguimientoDTO, SeguimientoRequestDTO, Seguimiento>
    {
        private readonly ISeguimientoService _service;
        public SeguimientosController(ISeguimientoService service,
            ICacheCleaner cacheCleaner, 
            ILogger<Seguimiento> logger) 
            : base(service, cacheCleaner, logger)
        {
            _service = service;
        }


        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetSeguimientoDetailAsync(Guid id)
        {
            var seguimientoDetail = await _service.GetSeguimientoDetailAsync(id);
            if (seguimientoDetail == null)
            {
                return NotFound();
            }
            return Ok(seguimientoDetail);
        }

        [HttpPost]
        [Authorize]
        public override async Task<ActionResult<SeguimientoDTO>> CreateAsync(SeguimientoRequestDTO seguimientoRequestDTO)
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(usuarioId == null)
            {
                return Unauthorized();
            }
            seguimientoRequestDTO.UsuarioId = Guid.Parse(usuarioId);
            return await base.CreateAsync(seguimientoRequestDTO);
        }

        [Authorize]
        [HttpGet("/api/mis-seguimientos")]
        public async Task<ActionResult<IEnumerable<SeguimientoDTO>>> GetSeguimientosByUsuarioIdAsync()
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(usuarioId == null)
            {
                return Unauthorized();
            }
            var seguimientos = await _service.GetSeguimientosByUsuarioIdAsync(Guid.Parse(usuarioId));
            return Ok(seguimientos);
        }
    }
}
