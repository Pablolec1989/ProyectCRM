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
    public class RolMapper : IRolMapper
    {
        public RolDTO ToDTO(Rol entity)
        {
            return new RolDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
            };
        }

        public Rol ToEntity(RolDTO dto)
        {
            return new Rol
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
            };
        }

        public Rol ToEntity(RolUpdateCreateDTO dto)
        {
            return new Rol
            {
                Nombre = dto.Nombre,
            };
        }

        public IEnumerable<RolDTO> ToListDTO(IEnumerable<Rol> entities)
        {
            return entities.Select(e => ToDTO(e)).ToList();
        }
    }
}
