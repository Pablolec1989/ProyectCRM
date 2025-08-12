using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.DTOs.RolDTOs;
using ProyectCRM.Service.DTOs.TipoDireccionDTOs;
using ProyectCRM.Service.DTOs.UsuarioDTOs;
using ProyectCRM.Service.DTOs.VisitaDTOs;
using ProyectCRM.Service.DTOs.VisitaUsuarioDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class VisitaMapper : IVisitaMapper
    {
        public VisitaDTO ToDTO(Visita entity)
        {
            return new VisitaDTO
            {
                Id = entity.Id,
                Cliente = entity.Cliente,
                Direccion = entity.Direccion,
                FechaProgramada = entity.FechaProgramada,
                FechaRealizada = entity.FechaRealizada,
                Observaciones = entity.Observaciones,
                Usuarios = entity.VisitasUsuarios?.Select(vu => new VisitasUsuariosDTO
                {
                    Usuarios = new List<UsuarioDTO>
                    {
                        new UsuarioDTO
                        {
                            Nombre = vu.Usuario.Nombre,
                            Apellido = vu.Usuario.Apellido,
                            Rol = new RolDTO
                            {
                                Id = vu.Usuario.Rol.Id,
                                Nombre = vu.Usuario.Rol.Nombre
                            },
                            Area = new AreaDTO
                            {
                                Id = vu.Usuario.Area.Id,
                                Nombre = vu.Usuario.Area.Nombre
                            },
                        }
                    }
                }).ToList()
            };

        }

        public Visita ToEntity(VisitaDTO dto)
        {
            throw new NotImplementedException();
        }

        public Visita ToEntity(VisitaUpdateCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VisitaDTO> ToListDTO(IEnumerable<Visita> entities)
        {
            throw new NotImplementedException();
        }
    }
}
