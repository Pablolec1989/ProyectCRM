using Mapster;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Mappers
{
    public class MailMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Mail, MailDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Detalle, src => src.Detalle)
                .Map(dest => dest.AsuntoDeContacto, src => src.AsuntoDeContacto.Adapt<AsuntoDeContactoDTO>())
                .Map(dest => dest.FechaMail, src => src.FechaMail);

            TypeAdapterConfig<Mail, MailDetailDTO>.NewConfig()
                .Map(dest => dest.Cliente, src => src.Cliente.Adapt<ClienteDTO>())
                .Map(dest => dest.Area, src => src.Area != null ? src.Area.Adapt<AreaDTO>() : null)
                .Map(dest => dest.Usuario, src => src.Usuario.Adapt<UsuarioDTO>());

            TypeAdapterConfig<MailRequestDTO, Mail>.NewConfig()
                .Map(dest => dest.Detalle, src => src.Detalle)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.UsuarioId, src => src.UsuarioId)
                .Map(dest => dest.AreaId, src => src.AreaId != null ? src.AreaId : null)
                .Map(dest => dest.AsuntoDeContactoId, src => src.AsuntoDeContactoId)
                .Map(dest => dest.FechaMail, src => src.FechaMail);
        }
    }
}
