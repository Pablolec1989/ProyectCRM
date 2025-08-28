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
    public class LlamadoRepository : RepositoryBase<Llamado>, ILlamadoRepository
    {
        private readonly AppDbContext _context;
        public LlamadoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Llamado> GetAllWithDetails()
        {
            return _context.Llamados
                .Include(ll => ll.AsuntoDeContacto)
                .Include(ll => ll.Cliente)
                .Include(ll => ll.Usuario)
                .Include(ll => ll.Area);
        }

        public override async Task<Llamado> GetByIdAsync(Guid id)
        {
            return await GetAllWithDetails()
                .FirstOrDefaultAsync(ll => ll.Id == id);
        }

        public override async Task<IEnumerable<Llamado>> GetAllAsync()
        {
            return await GetAllWithDetails()
                .ToListAsync();
        }
    }
}
