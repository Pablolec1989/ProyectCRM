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
    public class RolRepository : RepositoryBase<Rol>, IRolRepository
    {
        private readonly AppDbContext _context;

        public RolRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> RolExistsAsync(Guid id)
        {
            return await _context.Roles
                .AnyAsync(r => r.Id == id);
        }
    }
}
