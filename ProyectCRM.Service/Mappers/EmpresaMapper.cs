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
        public EmpresaDTO ToDTO(Empresa entity)
        {
            return new EmpresaDTO
            {
                Id = entity.Id,
                RazonSocial = entity.RazonSocial,
                CUIT = entity.CUIT,
                CUIL = entity.CUIL,
                Cliente = entity.Cliente != null ? new ClienteDTO
                {
                    Id = entity.Cliente.Id,
                    Nombre = entity.Cliente.Nombre,
                    Apellido = entity.Cliente.Apellido
                } : null,
                CondicionIva = entity.CondicionIva != null ? new CondicionIvaDTO
                {
                    Id = entity.CondicionIva.Id,
                    Nombre = entity.CondicionIva.Nombre
                } : null,
                Rubro = entity.Rubro != null ? new RubroDTO
                {
                    Id = entity.Rubro.Id,
                    Nombre = entity.Rubro.Nombre
                } : null,
            };
        }

        public Empresa ToEntity(EmpresaDTO dto)
        {
            return new Empresa
            {
                Id = dto.Id,
                RazonSocial = dto.RazonSocial,
                CUIT = dto.CUIT,
                CUIL = dto.CUIL,
                Cliente = dto.Cliente != null ? new Cliente
                {
                    Id = dto.Cliente.Id,
                    Nombre = dto.Cliente.Nombre,
                    Apellido = dto.Cliente.Apellido
                } : null,
                CondicionIva = dto.CondicionIva != null ? new CondicionIva
                {
                    Id = dto.CondicionIva.Id,
                    Nombre = dto.CondicionIva.Nombre
                } : null,
                Rubro = dto.Rubro != null ? new Rubro
                {
                    Id = dto.Rubro.Id,
                    Nombre = dto.Rubro.Nombre
                } : null,
            };
        }

        public Empresa ToEntity(EmpresaUpdateCreateDTO dto)
        {
            return new Empresa
            {
                Id = dto.Id,
                RazonSocial = dto.RazonSocial,
                CUIT = dto.CUIT,
                CUIL = dto.CUIL,
                ClienteId = dto.ClienteId,
                CondicionIvaId = dto.CondicionIvaId,
                RubroId = dto.RubroId
            };
        }

        public IEnumerable<EmpresaDTO> ToListDTO(IEnumerable<Empresa> entities)
        {
            return entities.Select(ToDTO).ToList();
        }
    }
}
