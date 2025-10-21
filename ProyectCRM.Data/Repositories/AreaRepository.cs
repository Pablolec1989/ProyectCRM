using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;

namespace ProyectCRM.Models.Data.Repositories
{
    public class AreaRepository : RepositoryBase<Area>, IAreaRepository
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Area> Areas()
        {
            return _context.Areas;
        }

        public async Task<bool> AreaExistsAsync(Guid id)
        {
            return await Areas()
                .AnyAsync(a => a.Id == id);
        }
    }
}
