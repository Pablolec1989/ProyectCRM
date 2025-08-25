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
    public class CondicionIvaMapper : ICondicionIvaMapper
    {
        public CondicionIvaDTO FromEntityToDto(CondicionIva entity)
        {
            return new CondicionIvaDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
            };
        }

        public CondicionIva FromRequestDtoToEntity(CondicionIvaRequestDTO dto)
        {
            return new CondicionIva
            {
                Nombre = dto.Nombre,
            };
        }

        public IEnumerable<CondicionIvaDTO> ToListDTO(IEnumerable<CondicionIva> entities)
        {
            return entities.Select(e => FromEntityToDto(e)).ToList();
        }
    }
}
