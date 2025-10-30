using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Repositories
{
    public class VisitaRepository : RepositoryBase<Visita>, IVisitaRepository
    {
        private readonly AppDbContext _context;

        public VisitaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Visita> Visitas()
        {
            return _context.Visitas
                .Include(v => v.Cliente)
                    .ThenInclude(c => c.Empresa)
                .Include(v => v.Direccion)
                    .ThenInclude(d => d.TipoDireccion);

        }

        public async Task<Visita> GetVisitaDetailAsync(Guid id)
        {
            return await Visitas()
                .Include(v => v.VisitasUsuarios)
                    .ThenInclude(vu => vu.Usuario)
                        .ThenInclude(u => u.Rol)
                .Include(v => v.VisitasUsuarios)
                    .ThenInclude(vu => vu.Usuario)
                        .ThenInclude(u => u.Area)
                .Include(v => v.Archivos)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public override async Task<Visita> GetByIdAsync(Guid id)
        {
            return await Visitas()
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public override async Task<IEnumerable<Visita>> SearchPaginatedAsync()
        {
            return await Visitas()
                        .ToListAsync();
        }

        public async Task<IEnumerable<Visita>> SearchByFilterAsync(VisitaFilterPaginated visitaFilterPaginated)
        {

            var query = Visitas();

            if (visitaFilterPaginated.Archivos.HasValue)
            {
                if (visitaFilterPaginated.Archivos.Value)
                    query = query.Where(v => v.Archivos != null && v.Archivos.Any());
                else
                    query = query.Where(v => v.Archivos == null || !v.Archivos.Any());
            }

            if (visitaFilterPaginated.FechaProgramadaDesde.HasValue)
                query = query.Where(v => v.FechaProgramada >= visitaFilterPaginated.FechaProgramadaDesde.Value);

            if (visitaFilterPaginated.FechaProgramadaHasta.HasValue)
                query = query.Where(v => v.FechaProgramada <= visitaFilterPaginated.FechaProgramadaHasta.Value);

            if (visitaFilterPaginated.FechaRealizadaDesde.HasValue)
                query = query.Where(v => v.FechaRealizada >= visitaFilterPaginated.FechaRealizadaDesde.Value);

            if (visitaFilterPaginated.FechaRealizadaHasta.HasValue)
                query = query.Where(v => v.FechaRealizada <= visitaFilterPaginated.FechaRealizadaHasta.Value);

            return await query
                .Paginate(visitaFilterPaginated.Pagination)
                .ToListAsync();

        }

    }
}
