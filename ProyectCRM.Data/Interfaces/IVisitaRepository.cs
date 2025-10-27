using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Interfaces
{
    public interface IVisitaRepository : IRepositoryBase<Visita>
    {
        Task<Visita> GetVisitaDetailAsync(Guid usuarioId);
        Task<IEnumerable<Visita>> SearchByFilterAsync(VisitaFilterPaginated visitaFilterPaginated);
    }
}
