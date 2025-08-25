using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
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
