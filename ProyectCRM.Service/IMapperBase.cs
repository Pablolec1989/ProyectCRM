using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service
{
    public interface IMapperBase<TDTO, TRequestDTO, TEntity>
        where TDTO : class 
        where TRequestDTO : class
        where TEntity : EntityBase
    {
        TDTO FromEntityToDto(TEntity entity);
        TEntity FromRequestDtoToEntity(TRequestDTO dto);
        IEnumerable<TDTO> ToListDTO(IEnumerable<TEntity> entities);
    }
}
