using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using ProyectCRM.Models.Entities;

namespace ProyectCRM.Models.Service.Mappers
{
    public class TipoDireccionMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<TipoDireccion, TipoDireccionDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();

            TypeAdapterConfig<TipoDireccionRequestDTO, TipoDireccion>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre);
        }
    }
}

