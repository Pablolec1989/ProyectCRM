using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;

namespace ProyectCRM.Models.Data.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        private readonly AppDbContext _context;

        public EmpresaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Empresa> Empresas()
        {
            return _context.Empresas;
        }

        public override async Task<Empresa> GetByIdAsync(Guid id)
        {
            return await Empresas()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Empresa>> SearchPaginated(PaginationDTO pagination)
        {
            return await Empresas()
                .Paginate(pagination)
                .ToListAsync();
        }

        public async Task<Empresa> GetEmpresaDetailDTOAsync(Guid id)
        {
            return await Empresas()
                .Include(e => e.CondicionIva)
                .Include(e => e.Rubro)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> GetEmpresaByRazonSocialAsync(string razonSocial)
        {
            return await _context.Empresas
                .AnyAsync(e => e.RazonSocial.ToLower() == razonSocial.ToLower());
        }

        public async Task<IEnumerable<Empresa>> GetAllPaged(PaginationDTO pagination)
        {
            return await Empresas()
                .OrderBy(e => e.RazonSocial)
                .Paginate(pagination)
                .ToListAsync();
        }
    }
}
