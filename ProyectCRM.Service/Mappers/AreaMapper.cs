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
    public class AreaMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Area, AreaDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();

            TypeAdapterConfig<AreaRequestDTO, Area>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre);
        }
    }
}
