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
    public class AsuntoDeContactoMapper
    {
        public void RegisterMappings()
        {            
            TypeAdapterConfig<AsuntoDeContacto, AsuntoDeContactoDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();

            TypeAdapterConfig<AsuntoDeContactoRequestDTO, AsuntoDeContacto>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre);
        }
    }
}
