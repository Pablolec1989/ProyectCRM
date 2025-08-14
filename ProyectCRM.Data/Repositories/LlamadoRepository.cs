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
    public class LlamadoRepository : RepositoryBase<Llamado>, ILlamadoRepository
    {
        private readonly AppDbContext _context;
        public LlamadoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Llamado> GetByIdAsync(Guid id)
        {
            return await _context.Llamadas
                .Include(ll => ll.Cliente)
                .Include(ll => ll.Usuario)
                .Include(ll => ll.Area)
                .FirstOrDefaultAsync(ll => ll.Id == id);
        }

        public override async Task<IEnumerable<Llamado>> GetAllAsync()
        {
            return await _context.Llamadas
                .Include(ll => ll.Cliente)
                .Include(ll => ll.Usuario)
                .Include(ll => ll.Area)
                .ToListAsync();
        }
}
