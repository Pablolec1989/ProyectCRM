using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AsuntoDeContactoDTO;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class AsuntoDeContactoMapper : IAsuntoDeContactoMapper
    {
        public DTOs.AsuntoDeContactoDTO.AsuntoDeContactoDTO ToDTO(Models.Entities.AsuntoDeContacto entity)
        {
            return new DTOs.AsuntoDeContactoDTO.AsuntoDeContactoDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
            };
        }

        public Models.Entities.AsuntoDeContacto ToEntity(DTOs.AsuntoDeContactoDTO.AsuntoDeContactoDTO dto)
        {
            return new Models.Entities.AsuntoDeContacto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
            };
        }

        public Models.Entities.AsuntoDeContacto ToEntity(AsuntoDeContactoUpdateCreateDTO dto)
        {
            return new Models.Entities.AsuntoDeContacto
            {
                Nombre = dto.Nombre,
            };
        }

        public IEnumerable<DTOs.AsuntoDeContactoDTO.AsuntoDeContactoDTO> ToListDTO(IEnumerable<Models.Entities.AsuntoDeContacto> entities)
        {
            return entities.Select(e => ToDTO(e));
        }
    }
}
