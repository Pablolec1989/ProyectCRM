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
    public class VisitaRepository : RepositoryBase<Visita>, IVisitaRepository
    {
        private readonly AppDbContext _context;

        public VisitaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Visita> GetByIdAsync(Guid id)
        {
            return await _context.Visitas
                .Include(v => v.Cliente).ThenInclude(c => c.Empresa)
                .Include(v => v.Direccion).ThenInclude(d => d.TipoDireccion)
                .Include(v => v.VisitasUsuarios).ThenInclude(vu => vu.Usuario)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
        public override async Task<IEnumerable<Visita>> GetAllAsync()
        {
            return await _context.Visitas
                .Include(v => v.Cliente).ThenInclude(c => c.Empresa)
                .Include(v => v.Direccion).ThenInclude(d => d.TipoDireccion)
                .Include(v => v.VisitasUsuarios).ThenInclude(vu => vu.Usuario)
                .ToListAsync();
        }

    }
}
