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

        public override async Task<Seguimiento> GetByIdAsync(Guid id)
        {
            return await _context.Seguimientos
                .Include(s => s.Usuario)
                .Include(s => s.Cliente).ThenInclude(c => c.Empresa)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public override async Task<IEnumerable<Seguimiento>> GetAllAsync()
        {
            return await _context.Seguimientos
                .Include(s => s.Usuario)
                .Include(s => s.Cliente).ThenInclude(c => c.Empresa)
                .ToListAsync();
        }
    }
}
