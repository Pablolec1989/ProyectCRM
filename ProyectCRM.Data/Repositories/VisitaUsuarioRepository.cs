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
    public class VisitaUsuarioRepository : RepositoryBase<VisitasUsuariosDTO>, IVisitaUsuarioRepository
    {
        private readonly AppDbContext _context;

        public VisitaUsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
