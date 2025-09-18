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
    public class TelefonoRepository : RepositoryBase<Telefonos>, ITelefonoRepository
    {
        private readonly AppDbContext _context;

        public TelefonoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Telefonos> Telefonos()
        {
            return _context.Telefonos
                .Include(tc => tc.Cliente)
                .Include(tc => tc.TipoTelefono)
                .AsQueryable();
        }

        public async Task<Telefonos> GetTelefonosByClienteIdAsync(Guid clienteId)
        {
            return await Telefonos()
                .FirstOrDefaultAsync(tc => tc.Id == clienteId);
        }

        public override async Task<IEnumerable<Telefonos>> GetAllAsync()
        {
            return await Telefonos()
                .ToListAsync();
        }
    }
}
