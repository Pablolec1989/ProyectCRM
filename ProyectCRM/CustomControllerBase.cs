using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ProyectCRM.Service;

namespace ProyectCRM
{
    [ApiController]
    public class CustomControllerBase<TDTO, TEntity> : ControllerBase, ICustomControllerBase<TDTO, TEntity>
                where TDTO : class
                where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public CustomControllerBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        [HttpPost]
        public async Task<ActionResult<TDTO>> CreateAsync(TEntity entity)
        {
            var created = await _serviceBase.CreateAsync(entity);
            if (created == null)
                return BadRequest("No se pudo crear la entidad");
            return Ok(created);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            return await _serviceBase.DeleteAsync(id) ? NoContent() : NotFound("No se ha encontrado la entidad");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync()
        {
            var results = await _serviceBase.GetAllAsync();
            if(results == null)
            {
                return NotFound("No se han encontrado entidades");
            }
            return Ok(results);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDTO>> GetByIdAsync(Guid id)
        {
            var area = await _serviceBase.GetByIdAsync(id);
            if (area == null)
            {
                return NotFound("No se ha encontrado la entidad");
            }
            return Ok(area);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDTO>> UpdateAsync(Guid id, TEntity entity)
        {
            var updated = await _serviceBase.UpdateAsync(id, entity);
            if (updated == null)
            {
                return NotFound("No se ha encontrado la entidad para actualizarla");
            }
            return Ok(updated);
        }
    }
}
