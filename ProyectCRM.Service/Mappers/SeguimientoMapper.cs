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
    public class SeguimientoMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Seguimiento, SeguimientoDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Titulo, src => src.Titulo)
                .Map(dest => dest.Detalle, src => src.Detalle)
                .Map(dest => dest.FechaCreacion, src => src.FechaCreacion);

            TypeAdapterConfig<Seguimiento, SeguimientoDetailDTO>.NewConfig()
                .Map(dest => dest.Area, src => src.Area != null ? src.Area.Adapt<AreaDTO>() : null)
                .Map(dest => dest.Cliente, src => src.Cliente.Adapt<ClienteDTO>())
                .Map(dest => dest.Usuario, src => src.Usuario.Adapt<UsuarioDTO>());

            TypeAdapterConfig<SeguimientoRequestDTO, Seguimiento>.NewConfig()
                .Map(dest => dest.Titulo, src => src.Titulo)
                .Map(dest => dest.Detalle, src => src.Detalle)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.UsuarioId, src => src.UsuarioId)
                .Map(dest => dest.AreaId, src => src.AreaId != null ? src.AreaId : null);

        }

    }
}
