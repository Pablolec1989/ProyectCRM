using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Interfaces;
using ProyectCRM.Models.Service;
using ProyectCRM.Utils;

namespace ProyectCRM.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CustomControllerBase<TDTO, TRequestDTO, TEntity>
        : ControllerBase, ICustomControllerBase<TDTO, TRequestDTO, TEntity>
        where TDTO : class
        where TRequestDTO : class, new()
        where TEntity : EntityBase
    {
        private readonly IServiceBase<TDTO, TRequestDTO, TEntity> _serviceBase;
        private readonly IOutputCacheStore _outputCacheStore;
        protected virtual string CacheTag => string.Empty;

        public CustomControllerBase(IServiceBase<TDTO, TRequestDTO, TEntity> serviceBase, IOutputCacheStore outputCacheStore)
        {
            _serviceBase = serviceBase;
            _outputCacheStore = outputCacheStore;
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
                return BadRequest("No se pudo crear");
            }
            await CleanCacheStoreAsync();
            return Ok(createdDto);
        }


        [HttpDelete("{id:Guid}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _serviceBase.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }
            await CleanCacheStoreAsync();
            return NotFound();
        }


        [HttpGet]
        [OutputCache]
        public virtual async Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync()
        {
            var dtos = await _serviceBase.GetAllAsync();

            HttpContext.InsertarParametrosPaginacionEnCabecera<TDTO>(dtos.Count());

            if (dtos == null)
            {
                return NotFound();
            }
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
                return NotFound();
            }
            await CleanCacheStoreAsync();
            return Ok(updatedDto);
        }

        //Metodo aux
        private async Task CleanCacheStoreAsync()
        {
            if (string.IsNullOrWhiteSpace(CacheTag)) return;

            await _outputCacheStore.EvictByTagAsync(CacheTag, CancellationToken.None);
        }
    }
}
