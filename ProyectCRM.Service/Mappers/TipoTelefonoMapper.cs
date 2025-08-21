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
    public class TipoTelefonoMapper : ITipoTelefonoMapper
    {
        public TipoTelefonoDTO FromEntityToDto(TipoTelefono entity)
        {
            return new TipoTelefonoDTO()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
            };
        }

        public TipoTelefono FromRequestDtoToEntity(TipoTelefonoRequestDTO dto)
        {
            return new TipoTelefono()
            {
                Nombre = dto.Nombre
            };
        }

        public IEnumerable<TipoTelefonoDTO> ToListDTO(IEnumerable<TipoTelefono> entities)
        {
            return entities.Select(e => FromEntityToDto(e)).ToList();
        }
    }
}
