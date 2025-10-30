using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;

namespace ProyectCRM.Models.Data.Repositories
{
    public class AreaRepository : RepositoryBase<AreaFilterPaginatedDTO, Area>, IAreaRepository
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Area> AreasQuery()
        {
            return _context.Areas;
        }

        public override async Task<IEnumerable<Area>> SearchPaginatedAsync(AreaFilterPaginatedDTO areaFilterPaginated)
        {
            var query = AreasQuery();

            if(!string.IsNullOrEmpty(areaFilterPaginated.Nombre))
            {
                query = query.Where(a => a.Nombre.Contains(areaFilterPaginated.Nombre));
            }
            
            var areas = await query.OrderBy(a => a.Nombre)
                .Paginate(areaFilterPaginated.Pagination)
                .ToListAsync();

            return areas;
        }

    }
}
