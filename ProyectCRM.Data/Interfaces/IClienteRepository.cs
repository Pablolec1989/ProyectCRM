using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        IQueryable<Cliente> ClientesQuery();
        Task<Cliente> GetClienteDetailAsync(Guid id);
        Task<Cliente> GetClienteByNombreApellidoAsync(Guid id);
        Task<IEnumerable<Cliente>> SearchClienteAsync(ClienteFilterPaginated clienteFilterPaginated);
    }
}
