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
    public class MailMapper : IMailMapper
    {
        public MailDTO ToDTO(Mail entity)
        {
            return new MailDTO
            {
                Id = entity.Id,
                Detalle = entity.Detalle,
                FechaMail = entity.FechaMail,
                Cliente = new ClienteDTO
                {
                    Id = entity.Cliente.Id,
                    Nombre = entity.Cliente.Nombre,
                    Empresa = new EmpresaDTO
                    {
                        Id = entity.Cliente.Empresa.Id,
                        RazonSocial = entity.Cliente.Empresa.RazonSocial
                    }
                },
                Usuario = new UsuarioDTO
                {
                    Id = entity.Usuario.Id,
                    Nombre = entity.Usuario.Nombre,
                    Area = new AreaDTO
                    {
                        Id = entity.Usuario.Area.Id,
                        Nombre = entity.Usuario.Area.Nombre
                    }
                },
                AsuntoDeContacto = new AsuntoDeContactoDTO
                {
                    Id = entity.AsuntoDeContacto.Id,
                    Nombre = entity.AsuntoDeContacto.Nombre
                }
            };
        }

        public Mail ToEntity(MailDTO dto)
        {
            return new Mail
            {
                Id = dto.Id,
                Detalle = dto.Detalle,
                FechaMail = dto.FechaMail,
                ClienteId = dto.Cliente.Id,
                UsuarioId = dto.Usuario.Id,
                AsuntoDeContactoId = dto.AsuntoDeContacto.Id
            };
        }

        public Mail ToEntity(MailUpdateCreateDTO dto)
        {
            return new Mail
            {
                Detalle = dto.Detalle,
                FechaMail = dto.FechaMail,
                ClienteId = dto.ClienteId,
                UsuarioId = dto.UsuarioId,
                AsuntoDeContactoId = dto.AsuntoDeContactoId
            };
        }

        public IEnumerable<MailDTO> ToListDTO(IEnumerable<Mail> entities)
        {
            return entities.Select(ToDTO);

        }
    }
}
