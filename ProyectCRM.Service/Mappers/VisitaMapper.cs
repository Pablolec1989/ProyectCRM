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
    public class VisitaMapper : IVisitaMapper
    {
        public VisitaDTO ToDTO(Visita entity)
        {
            return new VisitaDTO
            {
                Id = entity.Id,
                Cliente = new ClienteDTO
                {
                    Id = entity.Cliente.Id,
                    Nombre = entity.Cliente.Nombre,
                    Apellido = entity.Cliente.Apellido,
                    Empresa = new EmpresaDTO
                    {
                        RazonSocial = entity.Cliente.Empresa.RazonSocial,
                        Rubro = new RubroDTO
                        {
                            Id = entity.Cliente.Empresa.Rubro.Id,
                            Nombre = entity.Cliente.Empresa.Rubro.Nombre
                        },

                    }
                },
                DireccionCliente = new DireccionClienteDTO
                {
                    Direccion = new DireccionDTO
                    {
                        Id = entity.DireccionClienteId,
                        Calle = entity.Direccion.Calle,
                        Numero = entity.Direccion.Numero,
                        Ciudad = entity.Direccion.Ciudad,
                        Provincia = entity.Direccion.Provincia,
                        CodigoPostal = entity.Direccion.CodigoPostal

                    }
                },
                FechaProgramada = entity.FechaProgramada,
                FechaRealizada = entity.FechaRealizada,
                Observaciones = entity.Observaciones,
                Usuarios = new List<VisitaUsuarioDTO?>(entity.VisitasUsuarios
                .Select(vu => new VisitaUsuarioDTO
                {
                    Usuario = new UsuarioDTO
                    {
                        Id = vu.Usuario.Id,
                        Nombre = vu.Usuario.Nombre,
                        Apellido = vu.Usuario.Apellido,
                        Rol = new RolDTO
                        {
                            Id = vu.Usuario.RolId,
                            Nombre = vu.Usuario.Rol.Nombre
                        },
                        Area = new AreaDTO
                        {
                            Id = vu.Usuario.AreaId,
                            Nombre = vu.Usuario.Area.Nombre
                        }
                    },

                }).ToList()),
                Archivos = entity.Archivos?.Select(a => new ArchivoDTO
                {
                    NombreArchivo = a.NombreArchivo,
                    RutaArchivo = a.RutaArchivo,
                    FechaSubida = a.FechaSubida,

                }).ToList() ?? new List<ArchivoDTO>()
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
