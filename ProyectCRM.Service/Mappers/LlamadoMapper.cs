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
        public LlamadoDTO ToDTO(Llamado entity)
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
                },
                Area = new AreaDTO
                {
                    Id = entity.Area.Id,
                    Nombre = entity.Area.Nombre
                }
            };

        }

        public Llamado ToEntity(LlamadoDTO dto)
        {
            return new Llamado
            {
                Id = dto.Id,
                Detalle = dto.Detalle,
                AsuntoDeContacto = new AsuntoDeContacto
                {
                    Id = dto.AsuntoDeContacto.Id,
                    Nombre = dto.AsuntoDeContacto.Nombre
                },
                FechaLlamado = dto.FechaLlamado,
                Cliente = new Cliente
                {
                    Id = dto.Cliente.Id,
                    Nombre = dto.Cliente.Nombre,
                    Email = dto.Cliente.Email
                },
                Usuario = new Usuario
                {
                    Id = dto.Usuario.Id,
                    Nombre = dto.Usuario.Nombre
                },
                Area = new Area
                {
                    Id = dto.Area.Id,
                    Nombre = dto.Area.Nombre
                }
            };
        }

        public Llamado ToEntity(LlamadoUpdateCreateDTO dto)
        {
            return new Llamado
            {
                Id = dto.Id,
                Detalle = dto.Detalle,
                FechaLlamado = dto.FechaLlamado,
                ClienteId = dto.ClienteId,
                UsuarioId = dto.UsuarioId,
                AreaId = dto.AreaId,
                AsuntoDeContactoId = dto.AsuntoDeContactoId
            };
        }

        public IEnumerable<LlamadoDTO> ToListDTO(IEnumerable<Llamado> entities)
        {
            return entities.Select(ToDTO).ToList();
        }
    }
}
