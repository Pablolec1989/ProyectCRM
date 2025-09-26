using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        IQueryable<Cliente> Clientes();
        Task<Cliente> GetByIdWithAllDataAsync(Guid id);
        Task<Cliente> GetClienteByNombreApellidoAsync(Guid id);
    }
}
