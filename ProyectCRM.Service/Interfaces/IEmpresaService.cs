using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Interfaces
{
    public interface IEmpresaService : IServiceBase<EmpresaDTO, EmpresaRequestDTO, Empresa>
    {
        Task<EmpresaDetailDTO> GetEmpresaDetailDTOAsync(Guid id);
        Task<IEnumerable<EmpresaDTO>> SearchPaginatedAsync(PaginationDTO pagination);
    }
}
