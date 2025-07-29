using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Interfaces
{
    public interface IMapperBase<TDTO, TEntity>
        where TEntity : EntityBase
        where TDTO : class
    {
        TDTO ToDTO(TEntity entity);
        TEntity ToEntity(TDTO dto);
        IEnumerable<TDTO> ToListDTO(IEnumerable<TEntity> entities);
    }
}
