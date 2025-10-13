using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ProyectCRM.Models.Interfaces;
using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Service;
using ProyectCRM.Models.Service.DTOs;

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

        public CustomControllerBase(IServiceBase<TDTO, TRequestDTO, TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
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
        public virtual async Task<ActionResult<TDTO>> UpdateAsync(Guid id, TRequestDTO dto)
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
