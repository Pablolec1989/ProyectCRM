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
    public class UsuarioMapper : IUsuarioMapper
    {
        public UsuarioDTO FromEntityToDto(Usuario entity)
        {
            return new UsuarioDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Rol = new RolDTO
                {
                    Id = entity.RolId,
                    Nombre = entity.Rol.Nombre
                },
                Area = new AreaDTO
                {
                    Id = entity.AreaId,
                    Nombre = entity.Area.Nombre
                },
                Visitas = entity.VisitasUsuarios.Select(v => new VisitaUsuarioDTO
                {
                    Visita = new VisitaDTO
                    {
                        Id = v.VisitaId,
                        Observaciones = v.Visita.Observaciones,
                        FechaProgramada = v.Visita.FechaProgramada,
                        FechaRealizada = v.Visita.FechaRealizada,
                        Cliente = new ClienteDTO
                        {
                            Nombre = v.Visita.Cliente.Nombre,
                            Apellido = v.Visita.Cliente.Apellido,
                            EmpresaCliente = new EmpresaDTO
                            {
                                RazonSocial = v.Visita.Cliente.Empresa.RazonSocial
                            }
                        }
                    },
                }).ToList()
            };
        }

        public Usuario FromRequestDtoToEntity(UsuarioRequestDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Password = dto.Password,
                RolId = dto.RolId,
                AreaId = dto.AreaId,
                VisitasUsuarios = new List<VisitaUsuario>()
            };
        }

        public IEnumerable<UsuarioDTO> ToListDTO(IEnumerable<Usuario> entities)
        {
            return entities.Select(e => FromEntityToDto(e)).ToList();
        }
    }
}
