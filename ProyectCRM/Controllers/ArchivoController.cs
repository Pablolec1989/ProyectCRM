using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProyectCRM.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.Service.Services;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    [ApiController]
    [Route("api/archivos")]
    public class ArchivoController : ControllerBase, IArchivoController<ArchivoDTO, ArchivoRequestDTO, Archivo>
    {
        private readonly IArchivoService _service;
        public ArchivoController(IArchivoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ArchivoDTO>> CreateAsync([FromForm] ArchivoRequestDTO dto, IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            var result = await _service.CreateAsync(dto, archivo);
            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchivoDTO>>> GetAllAsync([FromQuery] PaginationDTO pagination)
        {
            var archivos = await _service.SearchPaginated(pagination);
            return Ok(archivos);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ArchivoDTO>> GetByIdAsync(Guid id)
        {
            var archivo = await _service.GetByIdAsync(id);
            if(archivo == null)
            {
                return NotFound();
            }
            return Ok(archivo);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ArchivoDTO>> UpdateAsync(Guid id, [FromForm] ArchivoRequestDTO dto, IFormFile? archivo)
        {
            var archivoActualizado = await _service.UpdateAsync(id, dto, archivo);
            return Ok(archivoActualizado);

        }
    }
}
