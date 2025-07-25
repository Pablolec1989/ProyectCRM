using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ProyectCRM
{
    public interface ICustomControllerBase<TDTO, TEntity>
        where TDTO : class
        where TEntity : class
    {
        Task<ActionResult<TDTO>> GetByIdAsync(Guid id);
        Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync();
        Task<ActionResult<TDTO>> CreateAsync(TEntity entity);
        Task<ActionResult<TDTO>> UpdateAsync(Guid id, TEntity entity);
        Task<ActionResult> DeleteAsync(Guid id);
    }
}
