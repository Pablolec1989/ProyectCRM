using Mapster;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class VisitasUsuariosMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<VisitasUsuarios, VisitaUsuarioDTO>
                .NewConfig()
                .Map(dest => dest.Usuario, src => src.Usuario)
                .Map(dest => dest.Visita, src => src.Visita);

            TypeAdapterConfig<VisitaUsuarioRequestDTO, VisitasUsuarios>
                .NewConfig()
                .Map(dest => dest.UsuarioId, src => src.UsuarioId)
                .Map(dest => dest.VisitaId, src => src.VisitaId);
        }
    }
}
