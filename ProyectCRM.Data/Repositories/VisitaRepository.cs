using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
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
                .Include(v => v.Direccion)
                    .ThenInclude(d => d.TipoDireccion)
                .Include(v => v.VisitasUsuarios)
                    .ThenInclude(vu => vu.Usuario)
                .Include(v => v.Archivos)
                .AsQueryable();
        }

        public async Task<IEnumerable<Visita>> GetVisitasByUsuarioAsync(Guid usuarioId)
        {
            return await _context.Visitas
            .Where(v => v.VisitasUsuarios.Any(vu => vu.UsuarioId == usuarioId))
            .OrderByDescending(v => v.FechaProgramada)
            .ToListAsync();

        }

        public override async Task<IEnumerable<Visita>> GetAllAsync()
        {
            return await Visitas().ToListAsync();
        }
    }
}
