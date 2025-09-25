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
                .Map(dest => dest.Rol, src => src.Rol != null ? src.Rol.Nombre : null)
                .Map(dest => dest.Area, src => src.Area != null ? src.Area.Nombre : null);

            TypeAdapterConfig<Usuario, UsuarioDetailDTO>.NewConfig()
                .Map(dest => dest.Llamados, src => src.Llamados)
                .Map(dest => dest.Mails, src => src.Mails)
                .Map(dest => dest.Seguimientos, src => src.Seguimientos)
                .Map(dest => dest.Visitas, src => src.VisitasUsuarios
                .Select(vu => vu.Visita));

            TypeAdapterConfig<UsuarioRequestDTO, Usuario>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.AreaId, src => src.AreaId)
                .Map(dest => dest.RolId, src => src.RolId);
        }
        
    }
}
