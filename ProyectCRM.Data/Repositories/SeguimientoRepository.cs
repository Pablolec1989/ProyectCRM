using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Repositories
{
    public class SeguimientoRepository : RepositoryBase<Seguimiento>, ISeguimientoRepository
    {
        private readonly AppDbContext _context;

        public SeguimientoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Seguimiento> SeguimientosQuery()
        {
            return _context.Seguimientos
                .Include(s => s.Area)
                .Include(s => s.Cliente)
                    .ThenInclude(c => c.Empresa)
                .Include(s => s.Usuario)
                    .ThenInclude(u => u.Area)
                .Include(s => s.Usuario)
                    .ThenInclude(u => u.Rol);
        }

        public async Task<Seguimiento> GetSeguimientosDetailAsync(Guid id)
        {
            return await SeguimientosQuery()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public override async Task<Seguimiento> GetByIdAsync(Guid id)
        {
            return await SeguimientosQuery()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public override async Task<IEnumerable<Seguimiento>> SearchPaginatedAsync()
        {
            return await SeguimientosQuery()
                        .ToListAsync();
        }
        public async Task<IEnumerable<Seguimiento>> GetSeguimientosByUsuarioIdAsync(Guid usuarioId)
        {
            return await _context.Seguimientos
                .Where(s => s.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
