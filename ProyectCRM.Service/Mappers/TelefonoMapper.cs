using Mapster;
using Microsoft.AspNetCore.Routing.Constraints;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Mappers
{
    public class TelefonoMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Telefono, TelefonoDTO>.NewConfig()
                .Map(dest => dest.Numero, src => src.Numero)
                .Map(dest => dest.TipoTelefono, src => src.TipoTelefono.Adapt<TipoTelefonoDTO>())
                .Map(dest => dest.ClienteId, src => src.ClienteId);

            TypeAdapterConfig<TelefonoRequestDTO, Telefono>.NewConfig()
                .Map(dest => dest.Numero, src => src.Numero)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.TipoTelefonoId, src => src.TipoTelefonoId);
        }
    }
}
