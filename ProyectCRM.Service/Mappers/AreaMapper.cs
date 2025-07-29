using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class AreaMapper : IAreaMapper
    {
        public AreaDTO ToDTO(Area entity)
        {
            return new AreaDTO
            {
                nombre = entity.nombre
            };
        }

        public Area ToEntity(AreaDTO dto)
        {
            return new Area
            {
                nombre = dto.nombre
                // El id se asigna en el servicio
            };
        }

        public IEnumerable<AreaDTO> ToListDTO(IEnumerable<Area> entities)
        {
            return entities.Select(e => ToDTO(e)).ToList();
        }
    }
}
