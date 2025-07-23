using ProyectCRM.Data;
using ProyectCRM.Mapper.AreaDTOs;
using ProyectCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Mapper
{
    public class AreaMapper : IMapper<AreaDTO, AreaCreateUpdateDTO, Area>
    {
        public AreaDTO ToDTO(Area entity)
        {
            return new AreaDTO
            {
                nombre = entity.nombre
            };
        }

        public IEnumerable<AreaDTO> ToDTOList(IEnumerable<Area> areas)
        {
            return areas.Select(entity => ToDTO(entity));
        }

        public Area ToEntity(AreaCreateUpdateDTO createDTO)
        {
            return new Area
            {
                nombre = createDTO.nombre
            };
        }
    }
}
