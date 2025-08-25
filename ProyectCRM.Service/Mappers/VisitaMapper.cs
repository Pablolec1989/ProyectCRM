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
        public VisitaDTO FromEntityToDto(Visita entity)
        {
            return new VisitaDTO
            {
                Id = entity.Id,
                Cliente = new ClienteDTO
                {
                    Id = entity.Cliente.Id,
                    Nombre = entity.Cliente.Nombre,
                    Apellido = entity.Cliente.Apellido,
                    EmpresaCliente = new EmpresaDTO
                    {
                        RazonSocial = entity.Cliente.Empresa.RazonSocial,
                        Rubro = new RubroDTO
                        {
                            Nombre = entity.Cliente.Empresa.Rubro.Nombre
                        },

                    }
                },
                DireccionCliente = new DireccionDTO
                {
                    Id = entity.Direccion.Id,
                    Calle = entity.Direccion.Calle,
                    Numero = entity.Direccion.Numero,
                    Ciudad = entity.Direccion.Ciudad,
                    Provincia = entity.Direccion.Provincia,
                    CodigoPostal = entity.Direccion.CodigoPostal,
                    TipoDireccion = new TipoDireccionDTO
                    {
                        Nombre = entity.Direccion.TipoDireccion.Nombre
                    }
                },
                Observaciones = entity.Observaciones,
                Usuarios = entity.VisitasUsuarios?.Select(vu => new VisitaUsuarioDTO
                {
                    UsuarioId = vu.UsuarioId,
                    Usuario = vu.Usuario == null ? null : new UsuarioDTO
                    {
                        Id = vu.Usuario.Id,
                        Nombre = vu.Usuario.Nombre,
                        Apellido = vu.Usuario.Apellido,
                        Area = vu.Usuario.Area == null ? null : new AreaDTO
                        {
                            Nombre = vu.Usuario.Area.Nombre
                        }
                    },
                }).ToList(),
                Archivos = entity.Archivos?.Select(a => new ArchivoDTO
                {
                    NombreArchivo = a.NombreArchivo,
                    RutaArchivo = a.RutaArchivo,
                    FechaSubida = a.FechaSubida,

                }).ToList() ?? new List<ArchivoDTO>(),
                FechaProgramada = entity.FechaProgramada,
                FechaRealizada = entity.FechaRealizada,
            };
        }

        public Visita FromRequestDtoToEntity(VisitaRequestDTO dto)
        {
            return new Visita
            {
                ClienteId = dto.ClienteId,
                DireccionId = dto.DireccionId,
                FechaProgramada = dto.FechaProgramada,
                FechaRealizada = dto.FechaRealizada,
                VisitasUsuarios = dto.UsuariosIds.Select(id => new VisitaUsuario
                {
                    UsuarioId = id
                }).ToList(),

            };
                
        }

        public IEnumerable<VisitaDTO> ToListDTO(IEnumerable<Visita> entities)
        {
            throw new NotImplementedException();
        }
    }
}
