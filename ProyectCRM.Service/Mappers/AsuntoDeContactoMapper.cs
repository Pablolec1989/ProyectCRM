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
    public class AsuntoDeContactoMapper : IAsuntoDeContactoMapper
    {
        public AsuntoDeContactoDTO ToDTO(AsuntoDeContacto entity)
        {
            return new AsuntoDeContactoDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
            };
        }

        public AsuntoDeContacto ToEntity(AsuntoDeContactoDTO dto)
        {
            return new AsuntoDeContacto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
            };
        }

        public AsuntoDeContacto ToEntity(AsuntoDeContactoUpdateCreateDTO dto)
        {
            return new AsuntoDeContacto
            {
                Nombre = dto.Nombre,
            };
        }

        public IEnumerable<AsuntoDeContactoDTO> ToListDTO(IEnumerable<AsuntoDeContacto> entities)
        {
            return entities.Select(e => ToDTO(e));
        }
    }
}
