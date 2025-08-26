using ProyectCRM.Models.Entities;
using Mapster;
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
        public AsuntoDeContactoDTO FromEntityToDto(AsuntoDeContacto asuntoDeContacto)
        {
            return asuntoDeContacto.Adapt<AsuntoDeContactoDTO>();
        }

        public AsuntoDeContacto FromRequestDtoToEntity(AsuntoDeContactoRequestDTO dto)
        {
            return dto.Adapt<AsuntoDeContacto>();
        }

        public IEnumerable<AsuntoDeContactoDTO> ToListDTO(IEnumerable<AsuntoDeContacto> entities)
        {
            return entities.Adapt<IEnumerable<AsuntoDeContactoDTO>>();
        }
    }
}
