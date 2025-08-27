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
    public class VisitaUsuarioMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<VisitasUsuarios, VisitaUsuarioDTO>.NewConfig()
                .Map(dest => dest.Usuario, src => src.Usuario)
                .Map(dest => dest.Visita, src => src.Visita)
                .TwoWays();

            TypeAdapterConfig<VisitaUsuarioRequestDTO, VisitasUsuarios>.NewConfig()
                .Map(dest => dest.UsuarioId, src => src.UsuarioId)
                .Map(dest => dest.VisitaId, src => src.VisitaId)
                .TwoWays();
        }
    }
}
