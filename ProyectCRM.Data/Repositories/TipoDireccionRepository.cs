using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Data.Repositories
{
    public class TipoDireccionRepository : RepositoryBase<TipoDireccion>, ITipoDireccionRepository
    {
        public TipoDireccionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
