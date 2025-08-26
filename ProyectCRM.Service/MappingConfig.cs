using Mapster;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            //Area
            TypeAdapterConfig<Area, AreaDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();

            TypeAdapterConfig<AreaRequestDTO, Area>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre);

            //Asunto de Contacto
            TypeAdapterConfig<AsuntoDeContacto, AsuntoDeContactoDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();

            TypeAdapterConfig<AsuntoDeContactoRequestDTO, AsuntoDeContacto>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre);

        }
    }
}
