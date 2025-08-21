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
    public class EmpresaMapper : IEmpresaMapper
    {
        public EmpresaDTO FromEntityToDto(Empresa entity)
        {
            return new EmpresaDTO
            {
                Id = entity.Id,
                RazonSocial = entity.RazonSocial,
                CUIT = entity.CUIT,
                CUIL = entity.CUIL,
                ClienteId = entity.ClienteId,
                Cliente = new ClienteDTO
                {
                    Nombre = entity.Cliente.Nombre,
                    Apellido = entity.Cliente.Apellido
                },
                CondicionIvaId = entity.CondicionIvaId,
                CondicionIva = new CondicionIvaDTO
                {
                    Id = entity.CondicionIva.Id,
                    Nombre = entity.CondicionIva.Nombre
                },
                RubroId = entity.RubroId,
                Rubro = new RubroDTO
                {
                    Id = entity.Rubro.Id,
                    Nombre = entity.Rubro.Nombre
                }
            };
        }

        public Empresa FromRequestDtoToEntity(EmpresaRequestDTO dto)
        {
            return new Empresa
            {
                Id = dto.Id,
                RazonSocial = dto.RazonSocial,
                CUIT = dto.CUIT,
                CUIL = dto.CUIL,
                CondicionIvaId = dto.CondicionIvaId,
                RubroId = dto.RubroId
            };
        }

        public IEnumerable<EmpresaDTO> ToListDTO(IEnumerable<Empresa> entities)
        {
            return entities.Select(FromEntityToDto).ToList();
        }
    }
}
