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
    public class VisitaArchivoRepository : RepositoryBase<Archivo>, IArchivoRepository
    {
        private readonly AppDbContext _context;

        public VisitaArchivoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

