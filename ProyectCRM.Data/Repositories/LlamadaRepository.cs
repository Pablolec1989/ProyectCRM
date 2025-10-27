using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
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

        public IQueryable<Llamado> Llamados()
        {
            return _context.Llamados
                .Include(l => l.Usuario).ThenInclude(u => u.Area)
                .Include(l => l.Cliente).ThenInclude(c => c.Empresa)
                .Include(ll => ll.AsuntoDeContacto);
        }

        public async Task<Llamado> GetLlamadaCompletoByIdAsync(Guid id)
        {
            return await Llamados()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public override async Task<Llamado> GetByIdAsync(Guid id)
        {
            return await Llamados()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public override async Task<IEnumerable<Llamado>> GetAllAsync()
        {
            return await Llamados()
                        .ToListAsync();
        }


    }
}
