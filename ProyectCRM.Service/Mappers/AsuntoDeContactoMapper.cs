using Mapster;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Mappers
{
    public class AsuntoDeContactoMapper
    {
        public void RegisterMappings()
        {            
            TypeAdapterConfig<AsuntosDeContacto, AsuntoDeContactoDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();

            TypeAdapterConfig<AsuntoDeContactoRequestDTO, AsuntosDeContacto>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre);
        }
    }
}
