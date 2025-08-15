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
                        Calle = entity.DireccionCliente.Direccion.Calle,
                        Numero = entity.DireccionCliente.Direccion.Numero,
                        Ciudad = entity.DireccionCliente.Direccion.Ciudad,
                        Provincia = entity.DireccionCliente.Direccion.Provincia,
                        CodigoPostal = entity.DireccionCliente.Direccion.CodigoPostal,
                        TipoDireccion = new TipoDireccionDTO
                        {
                            Nombre = entity.DireccionCliente.Direccion.TipoDireccion.Nombre
                        }
                    }
                },
                FechaProgramada = entity.FechaProgramada,
                FechaRealizada = entity.FechaRealizada,
                Observaciones = entity.Observaciones,
                Usuarios = new List<VisitaUsuarioDTO?>(entity.VisitasUsuarios
                .Select(vu => new VisitaUsuarioDTO
                {
                    Usuarios = vu.Usuario != null ? new List<UsuarioDTO?>
                        {
                            new UsuarioDTO
                            {
                                Id = vu.Usuario.Id,
                                Nombre = vu.Usuario.Nombre,
                                Apellido = vu.Usuario.Apellido
                            }
                        } : new List<UsuarioDTO?>()

                }).ToList()),
                Archivos = entity.Archivos?.Select(a => new VisitaArchivoDTO
                {
                    NombreArchivo = a.NombreArchivo,
                    RutaArchivo = a.RutaArchivo,
                    FechaSubida = a.FechaSubida,

                }).ToList() ?? new List<VisitaArchivoDTO>()
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
