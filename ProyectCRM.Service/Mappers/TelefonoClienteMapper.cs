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
    public class TelefonoClienteMapper : ITelefonoClienteMapper
    {
        public TelefonoClienteDTO ToDTO(TelefonoCliente entity)
        {
            return new TelefonoClienteDTO
            {
                Id = entity.Id,
                Numero = entity.Numero,
                Cliente = new List<ClienteDTO>()
                {
                   new ClienteDTO
                    {
                        Id = entity.ClienteId,
                        Nombre = entity.Cliente?.Nombre,
                        Apellido = entity.Cliente?.Apellido,
                    }
                },
                TipoTelefono = new List<TipoTelefonoDTO>()
                {
                    new TipoTelefonoDTO
                    {
                        Id = entity.TipoTelefonoId,
                        Nombre = entity.TipoTelefono?.Nombre
                    }
                }
            };
        }

        public TelefonoCliente ToEntity(TelefonoClienteDTO dto)
        {
            return new TelefonoCliente
            {
                Id = dto.Id,
                Numero = dto.Numero,
                ClienteId = dto.Cliente.FirstOrDefault()?.Id ?? Guid.Empty,
                TipoTelefonoId = dto.TipoTelefono.FirstOrDefault()?.Id ?? Guid.Empty
            };
        }

        public TelefonoCliente ToEntity(TelefonoClienteUpdateCreateDTO dto)
        {
            return new TelefonoCliente
            {
                Numero = dto.Numero,
                ClienteId = dto.ClienteId,
                TipoTelefonoId = dto.TipoTelefonoId
            };
        }

        public IEnumerable<TelefonoClienteDTO> ToListDTO(IEnumerable<TelefonoCliente> entities)
        {
            return entities.Select(ToDTO).ToList();
        }
    }
}
