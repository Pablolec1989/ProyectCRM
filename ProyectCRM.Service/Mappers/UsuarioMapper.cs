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
    public class UsuarioMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Usuario, UsuarioDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Area, src => src.Area)
                .TwoWays();

            TypeAdapterConfig<UsuarioRequestDTO, Usuario>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Password, src => src.Password)
                .Map(dest => dest.RolId, src => src.RolId)
                .Map(dest => dest.AreaId, src => src.AreaId)
                .TwoWays();
        }
        
    }
}
