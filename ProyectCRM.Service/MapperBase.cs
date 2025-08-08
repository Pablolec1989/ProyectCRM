using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public class MapperBase<TDTO, TEntity, TCreateDTO> : IMapperBase<TDTO, TCreateDTO, TEntity>
        where TDTO : BaseReadUpdateDTO, new()
        where TEntity : EntityBaseWithName, new()
        where TCreateDTO : BaseCreateDTO, new()
    {
        public TDTO ToDTO(TEntity entity)
        {
            return new TDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
            };
        }

        public TEntity ToEntity(TDTO dto)
        {
            return new TEntity
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
            };
        }

        public TEntity ToEntity(TCreateDTO dto)
        {
            return new TEntity
            {
                Nombre = dto.Nombre,
            };
        }

        public IEnumerable<TDTO> ToListDTO(IEnumerable<TEntity> entities)
        {
            return entities.Select(entity => ToDTO(entity)).ToList();
        }
    }
}
