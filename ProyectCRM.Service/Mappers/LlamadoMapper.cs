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
    public class LlamadoMapper : ILlamadoMapper
    {
        public LlamadoDTO FromEntityToDto(Llamado entity)
        {
            return new LlamadoDTO
            {
                Id = entity.Id,
                Detalle = entity.Detalle,
                AsuntoDeContacto = new AsuntoDeContactoDTO
                {
                    Id = entity.AsuntoDeContacto.Id,
                    Nombre = entity.AsuntoDeContacto.Nombre
                },
                FechaLlamado = entity.FechaLlamado,
                Cliente = new ClienteDTO
                {
                    Id = entity.Cliente.Id,
                    Nombre = entity.Cliente.Nombre,
                    Email = entity.Cliente.Email
                },
                Usuario = new UsuarioDTO
                {
                    Id = entity.Usuario.Id,
                    Nombre = entity.Usuario.Nombre,
                }
            };

        }

        public Llamado FromRequestDtoToEntity(LlamadoRequestDTO dto)
        {
            return new Llamado
            {
                Id = dto.Id,
                Detalle = dto.Detalle,
                FechaLlamado = dto.FechaLlamado,
                ClienteId = dto.ClienteId,
                UsuarioId = dto.UsuarioId,
                AsuntoDeContactoId = dto.AsuntoDeContactoId
            };
        }

        public IEnumerable<LlamadoDTO> ToListDTO(IEnumerable<Llamado> entities)
        {
            return entities.Select(FromEntityToDto).ToList();
        }
    }
}
