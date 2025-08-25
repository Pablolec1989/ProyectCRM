using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class AreaMapper : IAreaMapper
    {
        public AreaDTO FromEntityToDto(Area entity)
        {
            return new AreaDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
            };
        }

        public Area FromRequestDtoToEntity(AreaRequestDTO dto)
        {
            return new Area
            {
                Nombre = dto.Nombre,
            };
        }

        public IEnumerable<AreaDTO> ToListDTO(IEnumerable<Area> entities)
        {
            return entities.Select(e => FromEntityToDto(e)).ToList();
        }
    }
}
