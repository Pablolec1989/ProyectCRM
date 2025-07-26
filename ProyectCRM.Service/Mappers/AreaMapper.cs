using ProyectCRM.Models;
using ProyectCRM.Service.DTOs.AreaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class AreaMapper : IAreaMapper
    {
        public Task<AreaDTO> ToDTOAsync(Area area)
        {
            return Task.FromResult(new AreaDTO
            {
                nombre = area.nombre,
            });
        }

        public Task<IEnumerable<AreaDTO>> ToDTOListAsync(IEnumerable<Area> areas)
        {
            return Task.FromResult(areas.Select(area => new AreaDTO
            {
                nombre = area.nombre,
            }));
        }

        public Task<Area> ToEntityAsync(AreaDTO dto)
        {
            return Task.FromResult(new Area
            {
                nombre = dto.nombre,
            });
        }
    }
}
