using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Mapper
{
    public interface IMapperBase<TDTO, TEntity> 
        where TDTO : class
        where TEntity : class
    {
        Task<TDTO> ToDTOAsync(TEntity entity);
        Task<TEntity> ToEntityAsync(TDTO dto);
        Task<IEnumerable<TDTO>> ToDTOListAsync(IEnumerable<TEntity> entities);
    }
}
