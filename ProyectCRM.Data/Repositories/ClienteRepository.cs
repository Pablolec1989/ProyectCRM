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
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Cliente> GetClientesQuery()
        {
            return _context.Clientes
                .Include(c => c.Telefonos).ThenInclude(t => t.TipoTelefono)
                .Include(c => c.Direcciones).ThenInclude(d => d.TipoDireccion)
                .Include(c => c.Visitas).ThenInclude(v => v.Direccion);
        }

        public override async Task<Cliente> GetByIdAsync(Guid id)
        {
            return await GetClientesQuery()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await GetClientesQuery()
                .ToListAsync();
        }
    }
}
