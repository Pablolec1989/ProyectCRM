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
    public class VisitaMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Visita, VisitaDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Observaciones, src => src.Observaciones)
                .Map(dest => dest.DireccionId, src => src.DireccionId)
                .Map(dest => dest.FechaProgramada, src => src.FechaProgramada)
                .Map(dest => dest.FechaRealizada, src => src.FechaRealizada)
                .Map(dest => dest.DireccionCliente, src => src.Direccion != null ? src.Direccion.Adapt<DireccionDTO>() : null);
        
            TypeAdapterConfig<VisitaRequestDTO, Visita>.NewConfig()
                .Map(dest => dest.Observaciones, src => src.Observaciones)
                .Map(dest => dest.DireccionId, src => src.DireccionId)
                .Map(dest => dest.FechaProgramada, src => src.FechaProgramada)
                .Map(dest => dest.FechaRealizada, src => src.FechaRealizada);
        }
    }
}
