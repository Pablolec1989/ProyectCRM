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
    public class LlamadoRepository : RepositoryBase<Llamada>, ILlamadoRepository
    {
        private readonly AppDbContext _context;
        public LlamadoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Llamada> GetAllWithDetails()
        {
            return _context.Llamadas
                .Include(ll => ll.AsuntoDeContacto)
                .Include(ll => ll.Cliente)
                .Include(ll => ll.Usuario)
                .Include(ll => ll.Area);
        }

        public override async Task<Llamada> GetByIdAsync(Guid id)
        {
            return await GetAllWithDetails()
                .FirstOrDefaultAsync(ll => ll.Id == id);
        }

        public override async Task<IEnumerable<Llamada>> GetAllAsync()
        {
            return await GetAllWithDetails()
                .ToListAsync();
        }
    }
}
