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
    public class AreaRepository : RepositoryBase<Area>, IAreaRepository
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AreaExistsAsync(Guid id)
        {
            return await _context.Areas
                .AnyAsync(a => a.Id == id);
        }
    }
}
