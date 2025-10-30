using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Controllers;
using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Interfaces;
using ProyectCRM.Models.Service;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Utils;

namespace ProyectCRM.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CustomControllerBase<TDTO, TRequestDTO, FilterPaginatedDTO, TEntity>
        : ControllerBase, ICustomControllerBase<TDTO, TRequestDTO, FilterPaginatedDTO, TEntity>
        where TDTO : class
        where TRequestDTO : class, new()
        where FilterPaginatedDTO : class
        where TEntity : EntityBase
    {
        private readonly IServiceBase<TDTO, TRequestDTO, FilterPaginatedDTO,  TEntity> _serviceBase;
        private readonly ICacheCleaner _cacheCleaner;
        private readonly ILogger<TEntity> _logger;

        protected virtual string CacheTag => string.Empty;

        public IServiceBase Service { get; }
        public ILogger<AreasController> Logger { get; }

        public CustomControllerBase(IServiceBase<TDTO, TRequestDTO, FilterPaginatedDTO, TEntity> serviceBase, 
            ICacheCleaner cacheCleaner, ILogger<TEntity> logger)
        {
            _serviceBase = serviceBase;
            _cacheCleaner = cacheCleaner;
            _logger = logger;
        }

        [HttpPost]
        public virtual async Task<ActionResult<TDTO>> CreateAsync([FromBody] TRequestDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var createdDto = await _serviceBase.CreateAsync(dto);
            if (createdDto == null)
            {
                _logger.LogError($"Error al crear {typeof(TEntity).Name}");
                return BadRequest("No se pudo crear");
            }
            await _cacheCleaner.CleanCacheByTagAsync(CacheTag);
            _logger.LogInformation($"Creación de {typeof(TEntity).Name} exitosa.");
            return Ok(createdDto);
        }


        [HttpDelete("{id:Guid}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _serviceBase.DeleteAsync(id);
            if (!result)
            {
                _logger.LogInformation($"Fallo al intentar eliminar {typeof(TEntity).Name}");   
                return NotFound();
            }
            _logger.LogInformation($"{typeof(TEntity).Name} eliminado correctamente");
            await _cacheCleaner.CleanCacheByTagAsync(CacheTag);
            return NoContent();
        }


        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDTO>>> SearchPaginatedAsync(FilterPaginatedDTO filterPaginatedDTO)
        {
            var dtos = await _serviceBase.SearchPaginatedAsync(filterPaginatedDTO);

            HttpContext.InsertarParametrosPaginacionEnCabecera<TDTO>(dtos.Count());

            if (dtos == null)
            {
                return NotFound();
            }
            _logger.LogInformation($"Registros de {typeof(TEntity).Name} obtenidos exitosamente");
            return Ok(dtos);
        }


        [HttpGet("{id:Guid}")]
        [OutputCache]
        public virtual async Task<ActionResult<TDTO>> GetByIdAsync(Guid id)
        {
            var dto = await _serviceBase.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }


        [HttpPut("{id:Guid}")]
        public virtual async Task<ActionResult<TDTO>> UpdateAsync(Guid id, TRequestDTO dto)
        {
            var updatedDto = await _serviceBase.UpdateAsync(id, dto);
            if (updatedDto == null)
            {
                _logger.LogInformation($"Error al actualizar {typeof(TEntity).Name}");
                return NotFound();
            }
            await _cacheCleaner.CleanCacheByTagAsync(CacheTag);
            _logger.LogInformation($"{typeof(TEntity).Name} actualizado correctamente");
            return Ok(updatedDto);
        }

    }
}
