using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Repositories
{
    public class VisitaRepository : RepositoryBase<Visita>, IVisitaRepository
    {
        private readonly AppDbContext _context;

        public VisitaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Visita> Visitas()
        {
            return _context.Visitas
                .Include(v => v.Cliente)
                    .ThenInclude(c => c.Empresa)
                .Include(v => v.Direccion)
                    .ThenInclude(d => d.TipoDireccion);

        }

        public async Task<Visita> GetVisitaCompletoByIdAsync(Guid id)
        {
            return await Visitas()
                .Include(v => v.VisitasUsuarios)
                    .ThenInclude(vu => vu.Usuario)
                        .ThenInclude(u => u.Area)
                .Include(v => v.Archivos)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public override async Task<Visita> GetByIdAsync(Guid id)
        {
            return await Visitas()
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public override async Task<IEnumerable<Visita>> SearchPaginated(PaginationDTO pagination)
        {
            return await Visitas()
                        .Paginate(pagination)
                        .ToListAsync();
        }

    }
}
