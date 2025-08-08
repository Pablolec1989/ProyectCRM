using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public interface IMapperBase<TDTO, TCreateDTO, TEntity>
        where TEntity : EntityBase
        where TCreateDTO : class
        where TDTO : class
    {
        TDTO ToDTO(TEntity entity);
        TEntity ToEntity(TDTO dto);
        TEntity ToEntity(TCreateDTO dto);
        IEnumerable<TDTO> ToListDTO(IEnumerable<TEntity> entities);
    }
}
