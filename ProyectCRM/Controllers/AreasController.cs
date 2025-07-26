using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models;
using ProyectCRM.Service;
using ProyectCRM.Service.DTOs.AreaDTOs;

namespace ProyectCRM.Controllers
{
    [ApiController]
    [Route("api/area")]
    public class AreasController : CustomControllerBase<AreaDTO, Area>, IAreaController
    {
        public AreasController(IServiceBase<AreaDTO, Area> serviceBase) : base(serviceBase) { }

        [HttpGet("{id}")]
        public override Task<ActionResult<AreaDTO>> GetByIdAsync(Guid id) => base.GetByIdAsync(id);

        [HttpGet]
        public override Task<ActionResult<IEnumerable<AreaDTO>>> GetAllAsync() => base.GetAllAsync();

        [HttpPost]
        public override Task<ActionResult<AreaDTO>> CreateAsync(AreaDTO dto) => base.CreateAsync(dto);

        [HttpPut("{id}")]
        public override Task<ActionResult<AreaDTO>> UpdateAsync(Guid id, AreaDTO dto) => base.UpdateAsync(id, dto);

        [HttpDelete("{id}")]
        public override Task<ActionResult> DeleteAsync(Guid id) => base.DeleteAsync(id);
    }
}
