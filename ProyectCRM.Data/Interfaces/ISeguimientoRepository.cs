using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface ISeguimientoRepository : IRepositoryBase<Seguimiento>
    {
        Task<Seguimiento> GetSeguimientosDetailAsync(Guid id);
        Task<IEnumerable<Seguimiento>> GetSeguimientosByUsuarioIdAsync(Guid usuarioId);

    }
}
