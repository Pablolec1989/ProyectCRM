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
    public class SeguimientoMapper : ISeguimientoMapper
    {
        public SeguimientoDTO ToDTO(Seguimiento entity)
        {
            return new SeguimientoDTO
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Detalle = entity.Detalle,
                FechaCreacion = entity.FechaCreacion,
                Cliente = new ClienteDTO
                {
                    Id = entity.Cliente.Id,
                    Nombre = entity.Cliente.Nombre,
                    Empresa = new EmpresaDTO
                    {
                        Id = entity.Cliente.Empresa.Id,
                        RazonSocial = entity.Cliente.Empresa.RazonSocial,
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
                }
            };
        }

        public Seguimiento ToEntity(SeguimientoDTO dto)
        {
            throw new NotImplementedException();
        }

        public Seguimiento ToEntity(SeguimientoUpdateCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeguimientoDTO> ToListDTO(IEnumerable<Seguimiento> entities)
        {
            throw new NotImplementedException();
        }
    }
}
