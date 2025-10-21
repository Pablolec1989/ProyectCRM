using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Data.Interfaces
{
    public interface IRepositorySearch<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity,bool>> predicate);
    }
}
