using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.DireccionDTO;
using ProyectCRM.Service.DTOs.TipoDireccionDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class DireccionMapper : IDireccionMapper
    {
        public DireccionDTO ToDTO(Direccion entity)
        {
            return new DireccionDTO
            {
                Id = entity.Id,
                Calle = entity.Calle,
                Numero = entity.Numero,
                Ciudad = entity.Ciudad,
                CodigoPostal = entity.CodigoPostal,
                Provincia = entity.Provincia,
                TipoDireccion = new TipoDireccionDTO
                {
                    Id = entity.TipoDireccion.Id,
                    Nombre = entity.TipoDireccion.Nombre
                }
            };
        }

        public Direccion ToEntity(DireccionDTO dto)
        {
            return new Direccion
            {
                Calle = dto.Calle,
                Numero = dto.Numero,
                Ciudad = dto.Ciudad,
                CodigoPostal = dto.CodigoPostal,
                Provincia = dto.Provincia,
                TipoDireccionId = dto.TipoDireccion.Id
            };
        }

        public Direccion ToEntity(DireccionCreateDTO dto)
        {
            return new Direccion
            {
                Calle = dto.Calle,
                Numero = dto.Numero,
                Ciudad = dto.Ciudad,
                CodigoPostal = dto.CodigoPostal,
                Provincia = dto.Provincia,
                TipoDireccionId = dto.TipoDireccionId
            };
        }

        public IEnumerable<DireccionDTO> ToListDTO(IEnumerable<Direccion> entities)
        {
            return entities.Select(entity => ToDTO(entity));
        }
    }
}
