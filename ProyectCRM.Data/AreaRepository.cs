using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Data
{
    public class AreaRepository : IRepository<Area>
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

        public async Task DeleteAsync(int id)
        {
            var area = _context.Area.FirstOrDefault(a => a.id == id);
            _context.Area.Remove(area);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _context.Area.ToListAsync();

        }

        public async Task<Area> GetByIdAsync(int id)
        {
            return await _context.Area.FirstOrDefaultAsync(a => a.id == id);
        }

        public async Task<Area> UpdateAsync(int id, Area areaUpdate)
        {
            var area = await _context.Area.FirstOrDefaultAsync(a => a.id == id);

            area.id = id;
            area.nombre = areaUpdate.nombre;
            _context.Area.Update(area);
            await _context.SaveChangesAsync();
            return area;
        }
    }

}
