using Mapster;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
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
                .Map(dest => dest.AreaId, src => src.AreaId)
                .Map(dest => dest.RolId, src => src.RolId)
                .Map(dest => dest.Area, src => src.Area != null ? new AreaDTO 
                    { Id = src.Area.Id, Nombre = src.Area.Nombre } : null)
                .Map(dest => dest.Rol, src => src.Rol != null ? new RolDTO 
                    { Id = src.Rol.Id, Nombre = src.Rol.Nombre } : null)
                .Map(dest => dest.Rol, src => src.Rol != null ? src.Rol.Nombre : null)
                .TwoWays();

            TypeAdapterConfig<UsuarioRegisterDTO, Usuario>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Password, src => src.Password)
                .Map(dest => dest.AreaId, src => src.AreaId)
                .Map(dest => dest.RolId, src => src.RolId)
                .TwoWays();
        }
        
    }
}
