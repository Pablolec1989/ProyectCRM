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

        public override async Task<TelefonoCliente> GetByIdAsync(Guid id)
        {
            return await _context.TelefonosClientes
                .Include(tc => tc.TipoTelefono)
                .Include(tc => tc.Cliente)
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<TelefonoCliente>> GetAllAsync()
        {
            return await _context.TelefonosClientes
                .Include(tc => tc.TipoTelefono)
                .Include(tc => tc.Cliente)
                .ToListAsync();
        }
    }
}
