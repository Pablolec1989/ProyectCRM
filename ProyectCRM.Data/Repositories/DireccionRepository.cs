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
    public class DireccionRepository : RepositoryBase<Direccion>, IDireccionRepository
    {
        private readonly AppDbContext _context;

        public DireccionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Direccion> GetByIdWithTipoDireccionAsync(Guid id)
        {
            return await _context.Direcciones
                .Include(d => d.TipoDireccion)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
