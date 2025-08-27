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
    public class TelefonoClienteRepository : RepositoryBase<TelefonosCliente>, ITelefonoClienteRepository
    {
        private readonly AppDbContext _context;

        public TelefonoClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TelefonosCliente> GetWithAllDetails()
        {
            return _context.TelefonosClientes
                .Include(tc => tc.Cliente)
                .Include(tc => tc.TipoTelefono)
                .AsQueryable();
        }

        public override async Task<TelefonosCliente> GetByIdAsync(Guid id)
        {
            return await GetWithAllDetails()
                .FirstOrDefaultAsync(tc => tc.Id == id);
        }

        public override async Task<IEnumerable<TelefonosCliente>> GetAllAsync()
        {
            return await GetWithAllDetails()
                .ToListAsync();
        }
    }
}
