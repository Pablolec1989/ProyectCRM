using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Data.Repositories
{
    public class RubroRepository : RepositoryBase<Rubro>, IRubroRepository
    {
        public RubroRepository(AppDbContext context) : base(context)
        {
        }
    }
}
