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
    public class DireccionRepository : RepositoryBase<Direccion>, IDireccionRepository
    {
        private readonly AppDbContext _context;

        public DireccionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Direccion> GetDireccionQuery()
        {
            return _context.Direcciones
                .Include(d => d.TipoDireccion)
                .Include(d => d.Cliente).ThenInclude(c => c.Empresa);
        }
        public override async Task<Direccion> GetByIdAsync(Guid id)
        {
            return await GetDireccionQuery()
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public override async Task<IEnumerable<Direccion>> GetAllAsync()
        {
            return await GetDireccionQuery()
                .ToListAsync();
        }
    }
}
