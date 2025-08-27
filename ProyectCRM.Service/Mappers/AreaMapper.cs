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
    public class AreaMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Area, AreaDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre);

            TypeAdapterConfig<AreaRequestDTO, Area>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre);
        }
    }
}
