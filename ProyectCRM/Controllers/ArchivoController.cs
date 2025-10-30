using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
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
        private readonly ICacheCleaner _cacheCleaner;
        private readonly ILogger<Archivo> _logger;

        public ArchivoController(IArchivoService service, ICacheCleaner cacheCleaner, ILogger<Archivo> logger)
        {
            _service = service;
            _cacheCleaner = cacheCleaner;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ArchivoDTO>> CreateAsync([FromForm] ArchivoRequestDTO dto, IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                _logger.LogInformation($"Error al crear archivo {typeof(Archivo).Name}");
                return BadRequest("No se pudo subir el archivo.");
            }
            var result = await _service.CreateAsync(dto, archivo);
            _logger.LogInformation($"Archivo creado correctamente");
            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            if(!result)
            {
                _logger.LogInformation($"Error al eliminar archivo {typeof(Archivo).Name}");
                return NotFound();
            }
            _logger.LogInformation($"Archivo eliminado correctamente");
            _cacheCleaner.CleanCacheByTagAsync("archivos").Wait();

            return NoContent();
        }

        [HttpGet]
        [OutputCache]
        public async Task<ActionResult<IEnumerable<ArchivoDTO>>> GetAllAsync()
        {
            var archivos = await _service.SearchPaginatedAsync();
            return Ok(archivos);
        }

        [HttpGet("{id:Guid}")]
        [OutputCache]
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
            if(archivoActualizado == null)
            {
                _logger.LogInformation($"Error al actualizar archivo {typeof(Archivo).Name}");
                return NotFound();
            }
            _logger.LogInformation($"Archivo actualizado correctamente");
            _cacheCleaner.CleanCacheByTagAsync("archivos").Wait();
            return Ok(archivoActualizado);

        }
    }
}
