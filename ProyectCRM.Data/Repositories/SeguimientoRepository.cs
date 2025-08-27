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
    public class SeguimientoRepository : RepositoryBase<Seguimiento>, ISeguimientoRepository
    {
        private readonly AppDbContext _context;

        public SeguimientoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
