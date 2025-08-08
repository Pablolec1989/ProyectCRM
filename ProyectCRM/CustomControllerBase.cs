using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ProyectCRM.Interfaces;
using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CustomControllerBase<TDTO, TCreateDTO, TEntity> 
        : ControllerBase, ICustomControllerBase<TDTO, TCreateDTO, TEntity>
        where TDTO : BaseReadUpdateDTO
        where TCreateDTO : BaseCreateDTO
        where TEntity : EntityBaseWithName
    {
        private readonly IServiceBase<TDTO, TCreateDTO, TEntity> _serviceBase;

        public CustomControllerBase(IServiceBase<TDTO, TCreateDTO, TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        [HttpPost]
        public virtual async Task<ActionResult<TDTO>> CreateAsync([FromBody] TCreateDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var createdDto = await _serviceBase.CreateAsync(dto);
            if (createdDto == null)
            {
                return BadRequest("Failed to create the entity.");
            }
            return Ok(createdDto);
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _serviceBase.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync()
        {
            var dtos = await _serviceBase.GetAllAsync();
            if (dtos == null)
            {
                return NotFound();
            }
            return Ok(dtos);
        }

        [HttpGet("{id:Guid}")]
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
        public virtual async Task<ActionResult<TDTO>> UpdateAsync(Guid id, [FromBody] TDTO dto)
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
