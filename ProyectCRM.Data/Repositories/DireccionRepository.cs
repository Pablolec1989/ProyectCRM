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

        public override async Task<Direccion> GetByIdAsync(Guid id)
        {
            return await _context.Direcciones
                .Include(d => d.TipoDireccion)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public override async Task<IEnumerable<Direccion>> GetAllAsync()
        {
            return await _context.Direcciones
                .Include(d => d.TipoDireccion)
                .ToListAsync();
        }
        public override async Task<Direccion> UpdateAsync(Direccion entity)
        {
            //Validar que exista el TipoDireccionId
            var tipoDireccionExiste = await _context.TiposDirecciones.FindAsync(entity.TipoDireccionId);
            if (tipoDireccionExiste == null)
            {
                throw new ArgumentException("El TipoDireccionId proporcionado no existe.");
            }

            //Actualiza entidad
            var existingEntity = await _context.Direcciones.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                return null;
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            return existingEntity;
        }
    }
}
