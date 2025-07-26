using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ProyectCRM.Service;

namespace ProyectCRM
{
    public class CustomControllerBase<TDTO, TEntity>
        : ControllerBase, ICustomControllerBase<TDTO, TEntity>
        where TDTO : class
        where TEntity : class
    {
        private readonly IServiceBase<TDTO, TEntity> _serviceBase;

        public CustomControllerBase(IServiceBase<TDTO, TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public virtual async Task<ActionResult<TDTO>> CreateAsync(TDTO dto)
        {
            return await _serviceBase.CreateAsync(dto);
        }

        public virtual async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _serviceBase.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        public virtual async Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync()
        {
            var dtos = await _serviceBase.GetAllAsync();
            if (dtos == null)
            {
                return NotFound();
            }
            return Ok(dtos);
        }

        public virtual async Task<ActionResult<TDTO>> GetByIdAsync(Guid id)
        {
            var dto = await _serviceBase.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        public virtual async Task<ActionResult<TDTO>> UpdateAsync(Guid id, TDTO dto)
        {
            var updatedDto = await _serviceBase.UpdateAsync(id, dto);
            if (updatedDto == null)
            {
                return NotFound();
            }
            return Ok(updatedDto);
        }
    }
}
