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
    public class VisitaUsuarioRepository : IVisitaUsuarioRepository<VisitasUsuarios>
    {
        private readonly AppDbContext _context;
        public VisitaUsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<VisitasUsuarios> entidades)
        {
            _context.VisitasUsuarios.AddRange(entidades);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByVisitaIdAsync(Guid visitaId)
        {
            var visitasUsuarios = _context.VisitasUsuarios
                .Where(vu => vu.VisitaId == visitaId);

            if (visitasUsuarios.Any())
            { 
                _context.VisitasUsuarios.RemoveRange(visitasUsuarios);
                await _context.SaveChangesAsync();
            }
        }
    }

}
