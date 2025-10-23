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
    public class SeguimientoRepository : RepositoryBase<Seguimiento>, ISeguimientoRepository
    {
        private readonly AppDbContext _context;

        public SeguimientoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Seguimiento> Seguimientos()
        {
            return _context.Seguimientos
                .Include(s => s.Area)
                .Include(s => s.Cliente)
                    .ThenInclude(c => c.Empresa)
                .Include(s => s.Usuario)
                    .ThenInclude(u => u.Area)
                .Include(s => s.Usuario)
                    .ThenInclude(u => u.Rol);
        }

        public async Task<Seguimiento> GetSeguimientoCompletoRepositoryByIdAsync(Guid id)
        {
            return await Seguimientos()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public override async Task<Seguimiento> GetByIdAsync(Guid id)
        {
            return await Seguimientos()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public override async Task<IEnumerable<Seguimiento>> SearchPaginated(PaginationDTO pagination)
        {
            return await Seguimientos()
                        .Paginate(pagination)
                        .ToListAsync();
        }
    }
}
