using Mapster;
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
    public class CondicionIvaMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<CondicionIva, CondicionIvaDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();

            TypeAdapterConfig<CondicionIvaRequestDTO, CondicionIva>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre);
        }

    }
}
