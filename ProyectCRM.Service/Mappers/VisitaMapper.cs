using Mapster;
using Microsoft.AspNetCore.Routing.Constraints;
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
    public class VisitaMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Visita, VisitaDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Cliente, src => src.Cliente)
                .Map(dest => dest.Direccion, src => src.Direccion.TipoDireccion.Nombre);

            TypeAdapterConfig<Visita, VisitaDetailDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Observaciones, src => src.Observaciones)
                .Map(dest => dest.Cliente, src => src.Cliente)
                .Map(dest => dest.Direccion, src => src.Direccion.TipoDireccion.Nombre)
                .Map(dest => dest.Usuarios, src => src.VisitasUsuarios
                    .Select(vu => vu.Usuario)
                    .Adapt<List<UsuarioDTO>>())
                .Map(dest => dest.Archivos, src => src.Archivos)
                .Map(dest => dest.FechaRealizada, src => src.FechaRealizada)
                .Map(dest => dest.FechaProgramada, src => src.FechaProgramada);

            TypeAdapterConfig<VisitaRequestDTO, Visita>.NewConfig()
                .Map(dest => dest.Observaciones, src => src.Observaciones)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.DireccionId, src => src.DireccionId)
                .Map(dest => dest.VisitasUsuarios, src => src.UsuariosIds)
                .Map(dest => dest.FechaProgramada, src => src.FechaProgramada)
                .Map(dest => dest.FechaRealizada, src => src.FechaRealizada);

            TypeAdapterConfig<Visita, VisitaConUsuariosDTO>.NewConfig()
                .Map(dest => dest.Cliente, src => src.Cliente)
                .Map(dest => dest.Direccion, src => src.Direccion)
                .Map(dest => dest.Usuarios, src => src.VisitasUsuarios.Select(vu => vu.Usuario).Adapt<List<UsuarioDTO>>());
        }
    }
}
