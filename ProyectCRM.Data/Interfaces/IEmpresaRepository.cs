using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        Task<Empresa> GetEmpresaDetailDTOAsync(Guid id);
        Task<bool> GetEmpresaByRazonSocialAsync(string razonSocial);
        Task<IEnumerable<Empresa>> GetAllPaged(PaginationDTO pagination);
    }
}
