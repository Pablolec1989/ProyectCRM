using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<Empresa>> SearchPaginatedAsync(PaginationDTO pagination)
        {
            return await _context.Empresas
                .Paginate(pagination)
                .ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetSearchAsync(Expression<Func<Empresa, bool>> predicate)
        {
            var empresas = await _context.Empresas
                .Where(predicate)
                .ToListAsync();

            return empresas;
        }
    }
}
