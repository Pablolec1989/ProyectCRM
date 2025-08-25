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
        public TelefonoClienteDTO FromEntityToDto(TelefonoCliente entity)
        {
            return new TelefonoClienteDTO
            {
                Numero = entity.Numero,
                Cliente = new ClienteDTO
                {
                    Id = entity.Cliente.Id,
                    Nombre = entity.Cliente.Nombre,
                    Apellido = entity.Cliente.Apellido,
                    EmpresaCliente = new EmpresaDTO
                    {
                        RazonSocial = entity.Cliente.Empresa.RazonSocial,
                    }
                }
            };
            
        }

        public TelefonoCliente FromRequestDtoToEntity(TelefonoClienteRequestDTO dto)
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
            return entities.Select(FromEntityToDto).ToList();
        }
    }
}
