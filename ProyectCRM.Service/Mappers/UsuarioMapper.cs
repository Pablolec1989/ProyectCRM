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
        public UsuarioDTO ToDTO(Usuario entity)
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
                    Visitas = v.Visita != null ? new List<VisitaDTO> { new VisitaDTO
                    {
                        Id = v.Visita.Id,
                        FechaProgramada = v.Visita.FechaProgramada,
                        FechaRealizada = v.Visita.FechaRealizada,
                        Observaciones = v.Visita.Observaciones,

                    } } : new List<VisitaDTO>()
                }).ToList()
            };
        }

        public Usuario ToEntity(UsuarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public Usuario ToEntity(UsuarioUpdateCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioDTO> ToListDTO(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }
    }
}
