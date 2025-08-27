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
    public class TipoTelefonoMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<TiposTelefono, TipoTelefonoDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();
        
            TypeAdapterConfig<TipoTelefonoRequestDTO, TiposTelefono>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .TwoWays();
        }
    }
}
