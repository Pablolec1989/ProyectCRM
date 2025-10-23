using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Interfaces
{
    public interface ICustomControllerBase<TDTO, TRequestDTO, TEntity>
        where TDTO : class
        where TRequestDTO : class, new()
        where TEntity : EntityBase
    {
        Task<ActionResult<TDTO>> GetByIdAsync(Guid id);
        Task<ActionResult<IEnumerable<TDTO>>> SearchPaginated([FromQuery] PaginationDTO pagination);
        Task<ActionResult<TDTO>> CreateAsync(TRequestDTO dto);
        Task<ActionResult<TDTO>> UpdateAsync(Guid id, TRequestDTO dto);
        Task<IActionResult> DeleteAsync(Guid id);
    }
}
