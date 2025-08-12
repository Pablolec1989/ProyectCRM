using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.TipoDireccionDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class TipoDireccionMapper : ITipoDireccionMapper
    {
        public TipoDireccionDTO ToDTO(TipoDireccion entity)
        {
            return new TipoDireccionDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
            };
        }
        public TipoDireccion ToEntity(TipoDireccionDTO dto)
        {
            return new TipoDireccion
            {
                Nombre = dto.Nombre,
            };
        }
        public TipoDireccion ToEntity(TipoDireccionUpdateCreateDTO dto)
        {
            return new TipoDireccion
            {
                Nombre = dto.Nombre,
            };
        }
        public IEnumerable<TipoDireccionDTO> ToListDTO(IEnumerable<TipoDireccion> entities)
        {
            return entities.Select(e => ToDTO(e)).ToList();
        }
    }
}
