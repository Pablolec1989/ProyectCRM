using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public interface IMapperBase<TDTO, TUpdateCreateDTO, TEntity>
        where TDTO : class 
        where TUpdateCreateDTO : class
        where TEntity : EntityBase
    {
        TDTO ToDTO(TEntity entity);
        TEntity ToEntity(TDTO dto);
        TEntity ToEntity(TUpdateCreateDTO dto);
        IEnumerable<TDTO> ToListDTO(IEnumerable<TEntity> entities);
    }
}
