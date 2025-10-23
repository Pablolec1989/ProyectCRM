using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Repositories
{
    public class TelefonoRepository : RepositoryBase<Telefono>, ITelefonoRepository
    {
        private readonly AppDbContext _context;

        public TelefonoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Telefono> Telefonos()
        {
            return _context.Telefonos
                .Include(tc => tc.Cliente)
                .Include(tc => tc.TipoTelefono);
        }

        public async Task<Telefono> GetTelefonosByClienteIdAsync(Guid clienteId)
        {
            return await Telefonos()
                .FirstOrDefaultAsync(tc => tc.Id == clienteId);
        }

        public override async Task<Telefono> GetByIdAsync(Guid id)
        {
            return await Telefonos()
                .FirstOrDefaultAsync(tc => tc.Id == id);
        }

        public override async Task<IEnumerable<Telefono>> SearchPaginated(PaginationDTO pagination)
        {
            return await Telefonos()
                .Paginate(pagination)
                .ToListAsync();
        }
    }
}
