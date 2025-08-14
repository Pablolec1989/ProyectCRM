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
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Cliente> GetByIdAsync(Guid id)
        {
            return await _context.Clientes
                .Include(c => c.Nombre)
                .Include(c => c.Apellido)
                .Include(c => c.Email)
                .Include(c => c.TelefonoCliente).ThenInclude(t => t.TipoTelefono)
                .Include(c => c.Empresa)
                .Include(c => c.DireccionCliente).ThenInclude(dc => dc.Direccion).ThenInclude(d => d.TipoDireccion)
                .Include(c => c.Visitas).ThenInclude(v => v.DireccionCliente).ThenInclude(dc => dc.Direccion)
                .Include(c => c.Llamados)
                .Include(c => c.Mails)
                .Include(c => c.Seguimientos)
                .FirstOrDefaultAsync(c => c.Id == id);

        }

        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Include(c => c.Nombre)
                .Include(c => c.Apellido)
                .Include(c => c.Email)
                .Include(c => c.TelefonoCliente).ThenInclude(t => t.TipoTelefono)
                .Include(c => c.Empresa)
                .Include(c => c.DireccionCliente).ThenInclude(dc => dc.Direccion).ThenInclude(d => d.TipoDireccion)
                .Include(c => c.Visitas).ThenInclude(v => v.DireccionCliente).ThenInclude(dc => dc.Direccion)
                .Include(c => c.Llamados)
                .Include(c => c.Mails)
                .Include(c => c.Seguimientos)
                .ToListAsync();
        }
    }
}
