using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ProyectCRM.Models.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Usuario> QueryUsuarios()
        {
            return _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Area);
        }

        public async Task<Usuario> GetUserDetailAsync(Guid id)
        {
            return await QueryUsuarios()
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
            return await QueryUsuarios()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await QueryUsuarios()
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> SearchByFilterAsync(UsuarioFilterDTO usuarioFilterDTO)
        {
            var query = QueryUsuarios();

            if(!string.IsNullOrEmpty(usuarioFilterDTO.Nombre))
            {
                query = query.Where(u => u.Nombre.Contains(usuarioFilterDTO.Nombre));
            }
            if(!string.IsNullOrEmpty(usuarioFilterDTO.Apellido))
            {
                query = query.Where(u => u.Apellido.Contains(usuarioFilterDTO.Apellido));
            }
            if(!string.IsNullOrEmpty(usuarioFilterDTO.RolId))
            {
                query = query.Where(u => u.RolId.ToString() == usuarioFilterDTO.RolId);
            }
            if(!string.IsNullOrEmpty(usuarioFilterDTO.AreaId))
            {
                query = query.Where(u => u.AreaId.ToString() == usuarioFilterDTO.AreaId);
            }

            //Aplicar ordenamiento dinamico
            if(!string.IsNullOrEmpty(usuarioFilterDTO.OrderBy))
            {
                var orderType = usuarioFilterDTO.OrderAsc ? "ascending" : "descending";

                try
                {
                    query = query.OrderBy($"{usuarioFilterDTO.OrderBy} {orderType}");
                }
                catch (Exception)
                {
                    query = query.OrderBy(u => u.Nombre);
                }
            }
            else
            {
                query = query.OrderBy(u=> u.Nombre);
            }

                var usuarios = await query
                            .Paginate(usuarioFilterDTO.Pagination)
                            .ToListAsync();
            return usuarios;
        }

        //Metodos auxiliares
        public async Task<bool> GetUsuarioByNombreYApellidoAsync(string nombre, string apellido)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Nombre == nombre && u.Apellido == apellido);
        }

        public async Task<Usuario> GetUserByApellidoAsync(string apellido)
        {

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Apellido == apellido);

            if (usuario == null)
                throw new Exception("Usuario inexistente");

            return usuario;
        }

        public async Task<List<Guid>> GetExistingUserIdsAsync(IEnumerable<Guid> ids)
        {
            return await _context.Usuarios
                .Where(u => ids.Contains(u.Id))
                .Select(u => u.Id)
                .ToListAsync();

        }
    }
}
