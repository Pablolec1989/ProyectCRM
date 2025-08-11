using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public interface IMapperBase<TDTO, TCreateDTO, TEntity>
        where TDTO : class 
        where TCreateDTO : class
        where TEntity : EntityBase
    {
        TDTO ToDTO(TEntity entity);
        TEntity ToEntity(TDTO dto);
        TEntity ToEntity(TCreateDTO dto);
        IEnumerable<TDTO> ToListDTO(IEnumerable<TEntity> entities);
    }
}
