using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ProyectCRM.Interfaces;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM
{
    public class CustomControllerBase<TDTO, TOutput>
        : ControllerBase, ICustomControllerBase<TDTO, TOutput>
        where TDTO : class
        where TOutput : class
    {
        private readonly IServiceBase<TDTO, TOutput> _serviceBase;

        public CustomControllerBase(IServiceBase<TDTO, TOutput> serviceBase)
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
