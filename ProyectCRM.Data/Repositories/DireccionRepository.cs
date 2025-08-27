using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Repositories
{
    public class DireccionRepository : RepositoryBase<Direccion>, IDireccionRepository
    {
        private readonly AppDbContext _context;

        public DireccionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Direccion> GetAllWithDetails()
        {
            return _context.Direcciones
                .Include(d => d.Cliente)
                .Include(d => d.TipoDireccion)
                .AsQueryable();
        }

        public async Task<Direccion> GetByIdAsync(Guid id)
        {
            return await GetAllWithDetails()
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Direccion>> GetAllAsync()
        {
            return await GetAllWithDetails().ToListAsync();
        }


    }
}
