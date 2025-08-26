using Mapster;
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
        public AreaDetailDTO FromEntityToDetailDTO(Area area)
        {
            return area.Adapt<AreaDetailDTO>();
        }

        public AreaDTO FromEntityToDto(Area area)
        {
            return area.Adapt<AreaDTO>();
        }

        public Area FromRequestDtoToEntity(AreaRequestDTO dto)
        {
            return dto.Adapt<Area>();
        }

        public IEnumerable<AreaDTO> ToListDTO(IEnumerable<Area> entities)
        {
            return entities.Select(e => e.Adapt<AreaDTO>());
        }
    }
}
