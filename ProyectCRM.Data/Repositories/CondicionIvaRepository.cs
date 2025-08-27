using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data.Repositories
{
    public class CondicionIvaRepository : RepositoryBase<CondicionIva>, ICondicionIvaRepository
    {
        public CondicionIvaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
