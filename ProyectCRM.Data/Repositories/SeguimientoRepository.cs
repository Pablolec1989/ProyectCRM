using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Data.Repositories
{
    public class SeguimientoRepository : RepositoryBase<Seguimiento>, ISeguimientoRepository
    {
        private readonly AppDbContext _context;

        public SeguimientoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Seguimiento> GetSeguimientoQuery()
        {
                return _context.Seguimientos
                .Include(s => s.Usuario)
                .Include(s => s.Cliente).ThenInclude(c => c.Empresa)
                .AsQueryable();
        }

        public override async Task<Seguimiento> GetByIdAsync(Guid id)
        {
            return await GetSeguimientoQuery()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public override async Task<IEnumerable<Seguimiento>> GetAllAsync()
        {
            return await GetSeguimientoQuery()
                .ToListAsync();
        }
    }
}
