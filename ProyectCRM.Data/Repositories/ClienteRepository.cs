using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
using System.Linq.Dynamic.Core;

namespace ProyectCRM.Models.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Cliente> ClientesQuery()
        {
            return _context.Clientes
                .Include(c => c.Empresa);
        }

        public async Task<Cliente> GetClienteDetailAsync(Guid id)
        {
            var cliente = await ClientesQuery()
                .Include(c => c.Direcciones)
                    .ThenInclude(d => d.TipoDireccion)
                .Include(c => c.Llamados)
                    .ThenInclude(l => l.AsuntoDeContacto)
                .Include(c => c.Mails)
                    .ThenInclude(m => m.AsuntoDeContacto)
                .Include(c => c.Seguimientos)
                .Include(c => c.Telefonos)
                    .ThenInclude(t => t.TipoTelefono)
                .Include(c => c.Visitas)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cliente;
        }

        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await ClientesQuery().ToListAsync();
        }

        public async Task<Cliente> GetClienteByNombreApellidoAsync(Guid id)
        {
            return await _context.Clientes
                .Where(c => c.Id == id)
                .Select(c => new Cliente
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> SearchClienteAsync(ClienteFilterPaginated clienteFilterPaginated)
        {
            var query = ClientesQuery();

            if(!string.IsNullOrEmpty(clienteFilterPaginated.Nombre))
            {
                query = query.Where(c => c.Nombre.Contains(clienteFilterPaginated.Nombre));
            }
            
            if(!string.IsNullOrEmpty(clienteFilterPaginated.Apellido))
            {
                query = query.Where(c => c.Apellido.Contains(clienteFilterPaginated.Apellido));
            }
        
            if(!string.IsNullOrEmpty(clienteFilterPaginated.Email))
            {
                query = query.Where(c => c.Email.Contains(clienteFilterPaginated.Email));
            }
            
            if(clienteFilterPaginated.Empresa.HasValue)
            {
                if(clienteFilterPaginated.Empresa.Value)
                {
                    query = query.Where(c => c.Empresa != null);
                }
                else
                {
                    query = query.Where(c => c.Empresa == null);
                }
            }

            if (!string.IsNullOrEmpty(clienteFilterPaginated.OrderBy))
            {
                var orderType = clienteFilterPaginated.OrderAsc ? "ascending" : "descending";

                try
                {
                    query = query.OrderBy($"{clienteFilterPaginated.OrderBy} {orderType}");
                }
                catch (Exception)
                {
                    query = query.OrderBy(u => u.Nombre);
                }
            }
            else
            {
                query = query.OrderBy(u => u.Nombre);
            }

            var clientes = await query
                .Paginate(clienteFilterPaginated.Pagination)
                .ToListAsync();

            return clientes;

        }
    }
}
