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
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Usuario> GetUsuarioQuery()
        {
            return _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Area)
                .Include(u => u.VisitasUsuarios).ThenInclude(vu => vu.Visita);
        }

        public override async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await GetUsuarioQuery()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await GetUsuarioQuery()
                .ToListAsync();
        }
    }
}
