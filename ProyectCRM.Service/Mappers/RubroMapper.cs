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
    public class RubroMapper : IRubroMapper
    {
        public RubroDTO ToDTO(Rubro entity)
        {
            return new RubroDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Empresas = new List<EmpresaDTO>(entity.Empresas.Select(e => new EmpresaDTO
                {
                    RazonSocial = e.RazonSocial,
                }))
            };
        }

        public Rubro ToEntity(RubroDTO dto)
        {
            return new Rubro
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
            };
        }

        public Rubro ToEntity(RubroUpdateCreateDTO dto)
        {
            return new Rubro
            {
                Nombre = dto.Nombre,
            };
        }

        public IEnumerable<RubroDTO> ToListDTO(IEnumerable<Rubro> entities)
        {
            return entities.Select(e => ToDTO(e)).ToList();
        }
    }
}
