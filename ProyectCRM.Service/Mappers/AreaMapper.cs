using ProyectCRM.Data;
using ProyectCRM.Mapper;
using ProyectCRM.Models;
using ProyectCRM.Service.DTOs.AreaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class AreaMapper : IMapperBase<AreaDTO, Area>
    {
        public Task<AreaDTO> ToDTOAsync(Area area)
        {
            return Task.FromResult(new AreaDTO
            {
                nombre = area.nombre,
            });
        }

        public async Task<Area> ToEntityAsync(AreaDTO dto)
        {
            return await Task.FromResult(new Area
            {
                nombre = dto.nombre,
            });
        }

        public async Task<IEnumerable<AreaDTO>> ToDTOListAsync(IEnumerable<Area> areas)
        {
            return await Task.FromResult(areas.Select(area => new AreaDTO
            {
                nombre = area.nombre,
            }));
        }
    }
}
