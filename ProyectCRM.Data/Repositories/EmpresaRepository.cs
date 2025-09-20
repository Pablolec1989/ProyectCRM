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
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        private readonly AppDbContext _context;

        public EmpresaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Empresa> Empresas()
        {
            return _context.Empresas
                .Include(e => e.CondicionIva)
                .Include(e => e.Rubro);
        }

        public async Task<bool> GetEmpresaByRazonSocial(string razonSocial)
        {
            return await _context.Empresas
                .AnyAsync(e => e.RazonSocial.ToLower() == razonSocial.ToLower());

        }


        public override async Task<Empresa> GetByIdAsync(Guid id)
        {
            return await Empresas()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await Empresas().ToListAsync();
        }
    }
}
