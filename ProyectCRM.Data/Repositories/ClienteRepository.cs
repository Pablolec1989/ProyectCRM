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
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Cliente> Clientes()
        {
            return _context.Clientes
                .Include(c => c.Empresa);
        }

        public async Task<Cliente> GetByIdWithAllDataAsync(Guid id)
        {
            var cliente = await Clientes()
                //.Include(c => c.Direcciones)
                //    .ThenInclude(d => d.TipoDireccion)
                ////.Include(c => c.Direcciones)
                //.Include(c => c.Llamados)
                //    .ThenInclude(l => l.AsuntoDeContacto)
                //.Include(c => c.Llamados)
                //    .ThenInclude(l => l.Usuario)
                //.Include(c => c.Mails)
                //    .ThenInclude(m => m.AsuntoDeContacto)
                .Include(c => c.Mails)
                //    .ThenInclude(m => m.Usuario)
                //.Include(c => c.Seguimientos)
                //    .ThenInclude(s => s.Usuario)
                //.Include(c => c.Telefonos)
                //    .ThenInclude(t => t.TipoTelefono)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cliente;
        }


        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await Clientes().ToListAsync();
        }

    }
}
