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
    public class ClienteMapper : IMapperBase<ClienteDTO, ClienteUpdateCreateDTO, Cliente>, IClienteMapper
    {
        public ClienteDTO ToDTO(Cliente entity)
        {
            return new ClienteDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Email = entity.Email,
                TelefonoCliente = entity.TelefonoCliente.Select(tc => new TelefonoClienteDTO
                {
                    Id = tc.Id,
                    Numero = tc.Numero,
                    TipoTelefono = new List<TipoTelefonoDTO>()
                    {
                        new TipoTelefonoDTO
                        {
                            Id = tc.TipoTelefono.Id,
                            Nombre = tc.TipoTelefono.Nombre
                        }
                    }
                }).ToList(),
                Empresa = new EmpresaDTO
                {
                    Id = entity.Empresa.Id,
                    RazonSocial = entity.Empresa.RazonSocial,
                },
                Direcciones = entity.Direccion.Select(dc => new DireccionClienteDTO
                {
                    Direccion = new DireccionDTO
                    {
                        Id = dc.Id,
                        Calle = dc.Calle,
                        Numero = dc.Numero,
                        Ciudad = dc.Ciudad,
                        Provincia = dc.Provincia,
                        CodigoPostal = dc.CodigoPostal,
                        TipoDireccion = new TipoDireccionDTO
                        {
                            Id = dc.TipoDireccion.Id,
                            Nombre = dc.TipoDireccion.Nombre
                        }
                    },
                }).ToList(),
                Visitas = entity.Visitas.Select(v => new VisitaDTO
                {
                    Observaciones = v.Observaciones,
                    FechaProgramada = v.FechaProgramada,
                    FechaRealizada = v.FechaRealizada,
                }).ToList(),
                Llamados = entity.Llamados.Select(l => new LlamadoDTO
                {
                    Id = l.Id,
                    Detalle = l.Detalle,
                    AsuntoDeContacto = new AsuntoDeContactoDTO
                    {
                        Id = l.AsuntoDeContacto.Id,
                        Nombre = l.AsuntoDeContacto.Nombre
                    },
                    Usuario = new UsuarioDTO
                    {
                        Id = l.Usuario.Id,
                        Nombre = l.Usuario.Nombre,
                        Apellido = l.Usuario.Apellido,
                        Area = new AreaDTO
                        {
                            Id = l.Usuario.Area.Id,
                            Nombre = l.Usuario.Area.Nombre
                        }
                    }

                }).ToList(),
                Mails = entity.Mails.Select(m => new MailDTO
                {
                    Id = m.Id,
                    Detalle = m.Detalle,
                    AsuntoDeContacto = new AsuntoDeContactoDTO
                    {
                        Id = m.AsuntoDeContacto.Id,
                        Nombre = m.AsuntoDeContacto.Nombre
                    },
                    Usuario = new UsuarioDTO
                    {
                        Id = m.Usuario.Id,
                        Nombre = m.Usuario.Nombre,
                        Apellido = m.Usuario.Apellido,
                        Area = new AreaDTO
                        {
                            Id = m.Usuario.Area.Id,
                            Nombre = m.Usuario.Area.Nombre
                        }
                    }
                }).ToList(),


            };
        }

        public Cliente ToEntity(ClienteDTO dto)
        {
            throw new NotImplementedException();
        }

        public Cliente ToEntity(ClienteUpdateCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteDTO> ToListDTO(IEnumerable<Cliente> entities)
        {
            throw new NotImplementedException();
        }
    }
}
