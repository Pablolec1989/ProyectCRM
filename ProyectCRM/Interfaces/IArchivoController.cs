using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Interfaces
{
    public interface IArchivoController<TDTO, TRequestDTO, T>
        where TDTO : class
        where TRequestDTO : class
        where T : class
    {
        Task<ActionResult<ArchivoDTO>> CreateAsync([FromForm] ArchivoRequestDTO dto, IFormFile archivo);
        Task<ActionResult<ArchivoDTO>> UpdateAsync(Guid id, [FromForm] ArchivoRequestDTO dto, IFormFile? archivo);
        Task<IActionResult> DeleteAsync(Guid id);
        Task<ActionResult<IEnumerable<ArchivoDTO>>> GetAllAsync(PaginationDTO pagination);
        Task<ActionResult<ArchivoDTO>> GetByIdAsync(Guid id);
    }
}
