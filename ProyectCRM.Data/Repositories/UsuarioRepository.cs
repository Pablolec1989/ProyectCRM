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

        public override async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _context.Usuarios
                .Include(u => u.Area)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> GetUserAsync(string usuario)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Apellido == usuario);
        }
    }
}
