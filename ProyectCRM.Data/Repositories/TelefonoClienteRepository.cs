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
    public class TelefonoClienteRepository : RepositoryBase<TelefonoCliente>, ITelefonoClienteRepository
    {
        private readonly AppDbContext _context;

        public TelefonoClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TelefonoCliente> GetTelefonoClienteQuery()
        {
            return _context.TelefonosClientes
            .Include(tc => tc.TipoTelefono)
            .Include(tc => tc.Cliente);
        }

        public override async Task<TelefonoCliente> GetByIdAsync(Guid id)
        {
            return await GetTelefonoClienteQuery()
                .FirstOrDefaultAsync(tc => tc.Id == id);
        }

        public override async Task<IEnumerable<TelefonoCliente>> GetAllAsync()
        {
            return await GetTelefonoClienteQuery()
                .ToListAsync();
        }
    }
}
