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
    public class VisitaUsuarioRepository : IVisitaUsuarioRepository<VisitaUsuario>
    {
        private readonly AppDbContext _context;
        public VisitaUsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<VisitaUsuario> entidades)
        {
            _context.VisitaUsuario.AddRange(entidades);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByVisitaIdAsync(Guid visitaId)
        {
            var visitasUsuarios = _context.VisitaUsuario
                .Where(vu => vu.VisitaId == visitaId);

            if (visitasUsuarios.Any())
            { 
                _context.VisitaUsuario.RemoveRange(visitasUsuarios);
                await _context.SaveChangesAsync();
            }
        }

    }

}
