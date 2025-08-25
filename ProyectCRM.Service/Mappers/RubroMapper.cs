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
    public class RubroMapper : IRubroMapper
    {
        public RubroDTO FromEntityToDto(Rubro entity)
        {
            return new RubroDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre
            };
        }

        public Rubro FromRequestDtoToEntity(RubroRequestDTO dto)
        {
            return new Rubro
            {
                Nombre = dto.Nombre,
            };
        }

        public IEnumerable<RubroDTO> ToListDTO(IEnumerable<Rubro> entities)
        {
            return entities.Select(e => FromEntityToDto(e)).ToList();
        }
    }
}
