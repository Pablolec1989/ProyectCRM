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
    public class ClienteMapper : IMapperBase<ClienteDTO, ClienteRequestDTO, Cliente>, IClienteMapper
    {
        public ClienteDTO FromEntityToDto(Cliente entity)
        {
            return new ClienteDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Email = entity.Email,
                EmpresaCliente = new EmpresaDTO
                {
                    RazonSocial = entity.Empresa?.RazonSocial,
                }
            };
        }

        public Cliente FromRequestDtoToEntity(ClienteRequestDTO dto)
        {
            return new Cliente
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                EmpresaId = dto.EmpresaId,
            };
        }

        public IEnumerable<ClienteDTO> ToListDTO(IEnumerable<Cliente> entities)
        {
            return entities.Select(e => FromEntityToDto(e)).ToList();
        }
    }
}
