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
                .Map(dest => dest.Area, src => src.Area.Adapt<AreaDTO>());

            TypeAdapterConfig<Usuario, UsuarioDetailDTO>.NewConfig()
                .Map(dest => dest.Llamados, src => src.Llamados.Adapt<List<LlamadaDTO>>())
                .Map(dest => dest.Mails, src => src.Mails.Adapt<List<MailDTO>>())
                .Map(dest => dest.Seguimientos, src => src.Seguimientos.Adapt<List<SeguimientoDTO>>())
                .Map(dest => dest.Visitas, src => src.VisitasUsuarios != null ? src.VisitasUsuarios
                    .Where(vu => vu.Visita != null)
                    .Select(vu => vu.Visita.Adapt<VisitaDTO>())
                    .ToList() : new List<VisitaDTO>());

            TypeAdapterConfig<UsuarioRequestDTO, Usuario>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.AreaId, src => src.AreaId);
        }
        
    }
}
