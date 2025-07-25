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
    public class AreaMapper : IMapperBase<AreaDTO, Area>
    {
        public AreaDTO ToDTOAsync(Area entity)
        {
            return new AreaDTO
            {
                nombre = entity.nombre
            };
        }

        public IEnumerable<AreaDTO> ToDTOListAsync(IEnumerable<Area> areas)
        {
            return areas.Select(entity => ToDTOAsync(entity));
        }

        public Area ToEntityAsync(AreaCreateUpdateDTO createDTO)
        {
            return new Area
            {
                nombre = createDTO.nombre
            };
        }



        Task<AreaDTO> IMapperBase<AreaDTO, Area>.ToDTOAsync(Area entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<AreaDTO>> IMapperBase<AreaDTO, Area>.ToDTOListAsync(IEnumerable<Area> entities)
        {
            throw new NotImplementedException();
        }
    }
}
