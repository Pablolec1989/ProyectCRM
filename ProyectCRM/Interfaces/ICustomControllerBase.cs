using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ProyectCRM.Interfaces
{
    public interface ICustomControllerBase<TDTO, TOutput>
        where TDTO : class
        where TOutput : class
    {
        Task<ActionResult<TDTO>> GetByIdAsync(Guid id);
        Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync();
        Task<ActionResult<TDTO>> CreateAsync(TDTO dto);
        Task<ActionResult<TDTO>> UpdateAsync(Guid id, TDTO dto);
        Task<ActionResult> DeleteAsync(Guid id);
    }
}
