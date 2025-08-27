using Mapster;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
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
                .Map(dest => dest.Cliente, src => src.Cliente)
                .Map(dest => dest.Usuario, src => src.Usuario)
                .Map(dest => dest.FechaMail, src => src.FechaMail)
                .TwoWays();

            TypeAdapterConfig<MailRequestDTO, Mail>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Detalle, src => src.Detalle)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.UsuarioId, src => src.UsuarioId)
                .Map(dest => dest.FechaMail, src => src.FechaMail)
                .TwoWays();
        }
    }
}
