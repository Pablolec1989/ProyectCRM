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
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        private readonly AppDbContext _context;
        public EmpresaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public AppDbContext Context { get; }

        public override async Task<Empresa> GetByIdAsync(Guid id)
        {
            return await _context.Empresas
                .Include(e => e.Cliente)
                .Include(e => e.CondicionIva)
                .Include(e => e.Rubro)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await _context.Empresas
                .Include(e => e.Cliente)
                .Include(e => e.CondicionIva)
                .Include(e => e.Rubro)
                .ToListAsync();
        }
}
