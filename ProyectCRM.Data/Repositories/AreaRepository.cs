using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Data.Repositories
{
    public class AreaRepository : IRepositoryBase<Area>
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Area> CreateAsync(Area area)
        {
            await _context.Area.AddAsync(area);
            await _context.SaveChangesAsync();
            return area;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var area = _context.Area.FirstOrDefault(a => a.id == id);
            if (area == null)
            {
                return false; // Area not found
            }
            _context.Area.Remove(area);
            await _context.SaveChangesAsync();
            return true;

        }

        public Task<bool> FiltrarPorNombreAsync(string args)
        {
            return _context.Area.AnyAsync(a => a.nombre == args);
        }

        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _context.Area.ToListAsync();

        }

        public async Task<Area> GetByIdAsync(Guid id)
        {
            return await _context.Area.FirstOrDefaultAsync(a => a.id == id);
        }

        public async Task<Area> UpdateAsync(Guid id, Area areaUpdate)
        {
            var area = await _context.Area.FirstOrDefaultAsync(a => a.id == id);
            if(area == null)
            {
                throw new Exception("La entidad no existe");
            }
            area.id = id;
            area.nombre = areaUpdate.nombre;
            _context.Area.Update(area);
            await _context.SaveChangesAsync();
            return area;
        }

    }

}
