using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Interfaces
{
    public interface ICustomControllerBase<TDTO, TCreateDTO, TEntity>
        where TDTO : BaseReadUpdateDTO
        where TCreateDTO : BaseCreateDTO
        where TEntity : EntityBaseWithName
    {
        Task<ActionResult<TDTO>> GetByIdAsync(Guid id);
        Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync();
        Task<ActionResult<TDTO>> CreateAsync(TCreateDTO dto);
        Task<ActionResult<TDTO>> UpdateAsync(Guid id, TDTO dto);
        Task<ActionResult> DeleteAsync(Guid id);
    }
}
