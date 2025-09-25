using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        Task<Empresa> GetEmpresaCompletoByIdAsync(Guid id);
        Task<bool> GetEmpresaByRazonSocial(string razonSocial);
    }
}
