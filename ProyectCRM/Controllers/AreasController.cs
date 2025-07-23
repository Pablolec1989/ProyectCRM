using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Mapper.AreaDTOs;
using ProyectCRM.Service;

namespace ProyectCRM.Controllers
{
    [ApiController]
    [Route("api/areas")]
    public class AreasController : ControllerBase
    {
        private readonly IService<AreaCreateUpdateDTO, AreaDTO> _service;

        public AreasController(IService<AreaCreateUpdateDTO, AreaDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var areas = await _service.GetAllAsync();
            return Ok(areas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var area = await _service.GetByIdAsync(id);
                return Ok(area);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AreaDTO>> Post([FromBody] AreaCreateUpdateDTO createDto)
        {
            try
            {
                var area = await _service.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = area.id }, area);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AreaDTO>> Put(int id, [FromBody] AreaCreateUpdateDTO updateDto)
        {
            try
            {
                var updatedArea = await _service.UpdateAsync(id, updateDto);
                return Ok(updatedArea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}


