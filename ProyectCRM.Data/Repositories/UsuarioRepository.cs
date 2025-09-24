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

        public IQueryable<Usuario> Usuarios()
        {
            //Traer toda la data relacionada al usuario
            return _context.Usuarios
                .Include(u => u.VisitasUsuarios)
                    .ThenInclude(vu => vu.Visita)
                        .ThenInclude(v => v.Cliente);

        }

        //Metodo especifico para mostrar toda la informacion del usuario
        public async Task<Usuario> GetUsuarioCompletoByIdAsync(Guid id)
        {
            return await Usuarios()
                .FirstOrDefaultAsync(u => u.Id == id);

        }

        public override async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await Usuarios()
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public override async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await Usuarios()
                .ToListAsync();
        }

        //Metodos auxiliares
        public async Task<bool> GetUsuarioByNombreYApellidoAsync(string nombre, string apellido)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Nombre == nombre && u.Apellido == apellido);
        }
        public async Task<List<Guid>> GetExistingUserIdsAsync(List<Guid> ids)
        {
            return await _context.Usuarios
                .Where(u => ids.Contains(u.Id))
                .Select(u => u.Id)
                .ToListAsync();
        }


    }
}
