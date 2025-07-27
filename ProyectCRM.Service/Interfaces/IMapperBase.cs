using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Interfaces
{
    public interface IMapperBase<TDTO, TOutput> 
        where TOutput : class
        where TDTO : class
    {
        Task<TDTO> ToDTOAsync(TOutput entity);
        Task<TOutput> ToEntityAsync(TDTO dto);
        Task<IEnumerable<TDTO>> ToDTOListAsync(IEnumerable<TOutput> entities);
    }
}
