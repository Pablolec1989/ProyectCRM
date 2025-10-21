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
            return _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Area);
;
        }

        //Metodo especifico para mostrar toda la informacion del usuario
        public async Task<Usuario> GetUserDetailAsync(Guid id)
        {
            return await Usuarios()
                .Include(u => u.Llamados)
                .Include(u => u.Mails)
                .Include(u => u.Seguimientos)
                .Include(u => u.VisitasUsuarios)
                    .ThenInclude(vu => vu.Visita)
                .Include(u => u.VisitasUsuarios)
                    .ThenInclude(vu => vu.Visita.Direccion)
                .Include(u => u.VisitasUsuarios)
                    .ThenInclude(u => u.Visita.Direccion.TipoDireccion)
                .Include(u => u.VisitasUsuarios)
                    .ThenInclude(vu => vu.Visita.Cliente)
                .Include(u => u.VisitasUsuarios)
                    .ThenInclude(vu => vu.Visita.Cliente.Empresa)
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

        public Task<List<Guid>> GetExistingUserIdsAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
