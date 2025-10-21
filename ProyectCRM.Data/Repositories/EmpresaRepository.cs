using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository, IRepositorySearch<Empresa>
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

        public override async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await Empresas()
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

        public async Task<IEnumerable<Empresa>> GetAsync(Expression<Func<Empresa, bool>> predicate)
        {
            var empresas = await _context.Empresas
                .Where(predicate)
                .ToListAsync();

            return empresas;
        }

    }
}
