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

        public IQueryable<Direccion> Direcciones()
        {
            return _context.Direcciones
                .Include(d => d.TipoDireccion)
                .Include(d => d.Cliente);
        }

        public async Task<Direccion> GetByIdAsync(Guid id)
        {
            return await Direcciones().ToListAsync();
        }

        public async Task<IEnumerable<Direccion>> GetAllAsync()
        {
            return await Direcciones()
                .Where(d => d.Cliente.Id == clienteId)
                .ToListAsync();
        }


    }
}
