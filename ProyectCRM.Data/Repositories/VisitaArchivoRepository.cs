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
    public class VisitaArchivoRepository : RepositoryBase<VisitaArchivo>, IVisitaArchivoRepository
    {
        private readonly AppDbContext _context;

        public VisitaArchivoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<VisitaArchivo> GetByIdAsync(Guid id)
        {
            return await _context.VisitasArchivos
                .Include(v => v.Visita)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public override async Task<IEnumerable<VisitaArchivo>> GetAllAsync()
        {
            return await _context.VisitasArchivos
                .Include(v => v.Visita)
                .ToListAsync();
        }
    }
}

