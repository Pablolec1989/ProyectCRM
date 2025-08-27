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
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Usuario> GetWitAllDetails()
        {
            return _context.Usuarios
                .Include(u => u.Area)
                .Include(u => u.Rol)
                .Include(u => u.Llamada)
                .Include(u => u.Mail)
                .Include(u => u.Seguimientos)
                .Include(u => u.Visitas);
        }

        public override async Task<Usuario?> GetByIdAsync(Guid id)
        {
            return await GetWitAllDetails()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await GetWitAllDetails()
                .ToListAsync();
        }

    }
}
