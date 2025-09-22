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
    public class LlamadoMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Llamado, LlamadaDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Detalle, src => src.Detalle)
                .Map(dest => dest.AsuntoDeContacto, src => src.AsuntoDeContacto)
                .Map(dest => dest.FechaLlamado, src => src.FechaLlamado);

            TypeAdapterConfig<Llamado, LlamadaDetailDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Detalle, src => src.Detalle)
                .Map(dest => dest.AsuntoDeContacto, src => src.AsuntoDeContacto)
                .Map(dest => dest.Cliente, src => src.Cliente)
                .Map(dest => dest.Usuario, src => src.Usuario)
                .Map(dest => dest.Area, src => src.Area)
                .Map(dest => dest.FechaLlamado, src => src.FechaLlamado);

            TypeAdapterConfig<LlamadaRequestDTO, Llamado>.NewConfig()
                .Map(dest => dest.Detalle, src => src.Detalle)
                .Map(dest => dest.AsuntoDeContactoId, src => src.AsuntoDeContactoId)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.UsuarioId, src => src.UsuarioId)
                .Map(dest => dest.AreaId, src => src.AreaId)
                .Map(dest => dest.FechaLlamado, src => src.FechaLlamado);
        }
    }
}
