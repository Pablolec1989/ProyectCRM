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
    public class VisitasUsuariosRepository : RepositoryBase<VisitaUsuario>, IVisitasUsuarios
    {
        private readonly AppDbContext _context;

        public VisitasUsuariosRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<VisitaUsuario> GetByIdAsync(Guid id)
        {
            return await _context.VisitasUsuarios
                .Include(vu => vu.Usuario)
                .Include(vu => vu.Visita)
                .FirstOrDefaultAsync(vu => vu.Id == id);
        }

        public override async Task<IEnumerable<VisitaUsuario>> GetAllAsync()
        {
            return await _context.VisitasUsuarios
                .Include(vu => vu.Usuario)
                .Include(vu => vu.Visita)
                .ToListAsync();
        }
    }
}
