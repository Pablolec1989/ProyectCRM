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
    public class TelefonoClienteMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<TelefonosCliente, TelefonoClienteDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Cliente, src => src.Cliente)
                .Map(dest => dest.Numero, src => src.Numero)
                .Map(dest => dest.TipoTelefono, src => src.TipoTelefono.Nombre)
                .TwoWays();

            TypeAdapterConfig<TelefonoClienteRequestDTO, TelefonosCliente>.NewConfig()
                .Map(dest => dest.Numero, src => src.Numero)
                .Map(dest => dest.TipoTelefonoId, src => src.TipoTelefonoId)
                .TwoWays();
        }
    }
}
