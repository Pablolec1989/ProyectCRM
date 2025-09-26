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
                .Map(dest => dest.Cliente, src => src.Cliente.Adapt<ClienteDTO>())
                .Map(dest => dest.Direccion, src => src.Direccion.Adapt<DireccionDTO>());

            TypeAdapterConfig<Visita, VisitaDetailDTO>.NewConfig()
                .Map(dest => dest.Observaciones, src => src.Observaciones)
                .Map(dest => dest.Usuarios, src => src.VisitasUsuarios != null ? src.VisitasUsuarios
                    .Where(vu => vu.Usuario != null)
                    .Select(vu => vu.Usuario.Adapt<UsuarioDTO>())
                    .ToList() : new List<UsuarioDTO>())
                .Map(dest => dest.Archivos, src => src.Archivos != null ? src.Archivos.Adapt<ArchivoDTO>() : null)
                .Map(dest => dest.FechaRealizada, src => src.FechaRealizada)
                .Map(dest => dest.FechaProgramada, src => src.FechaProgramada);

            TypeAdapterConfig<VisitaRequestDTO, Visita>.NewConfig()
                .Map(dest => dest.Observaciones, src => src.Observaciones)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.DireccionId, src => src.DireccionId)
                .Map(dest => dest.VisitasUsuarios, src => src.UsuariosIds
                    .Select(id => new VisitaUsuario { UsuarioId = id }).ToList())
                .Map(dest => dest.FechaProgramada, src => src.FechaProgramada)
                .Map(dest => dest.FechaRealizada, src => src.FechaRealizada);

        }
    }
}
