using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface IDireccionRepository : IRepositoryBase<Direccion>
    {
        Task<IEnumerable<Direccion>> GetDireccionesByClienteIdAsync(Guid clienteId);
        Task<Direccion> GetDireccionWithDetailsAsync(Guid id);
    }
}
