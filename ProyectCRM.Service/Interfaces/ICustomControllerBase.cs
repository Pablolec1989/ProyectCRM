using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Interfaces
{
    public interface ICustomControllerBase<TDTO, TUpdateCreateDTO, TEntity>
        where TDTO : class
        where TUpdateCreateDTO : class, new()
        where TEntity : EntityBase
    {
        Task<ActionResult<TDTO>> GetByIdAsync(Guid id);
        Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync();
        Task<ActionResult<TDTO>> CreateAsync(TUpdateCreateDTO dto);
        Task<ActionResult<TDTO>> UpdateAsync(Guid id, TUpdateCreateDTO dto);
        Task<ActionResult> DeleteAsync(Guid id);
    }
}
