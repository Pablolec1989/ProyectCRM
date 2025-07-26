using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public interface IMapperBase<TDTO, TEntity> 
        where TEntity : class
        where TDTO : class
    {
        Task<TDTO> ToDTOAsync(TEntity entity);
        Task<TEntity> ToEntityAsync(TDTO dto);
        Task<IEnumerable<TDTO>> ToDTOListAsync(IEnumerable<TEntity> entities);
    }
}
