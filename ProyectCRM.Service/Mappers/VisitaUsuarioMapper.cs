using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Mappers
{
    public class VisitaUsuarioMapper : IVisitaUsuarioMapper
    {
        public VisitaUsuarioDTO FromEntityToDto(VisitaUsuario entity)
        {
            return new VisitaUsuarioDTO
            {
                UsuarioId = entity.UsuarioId,
                VisitaId = entity.VisitaId,
            };
        }

        public VisitaUsuario FromDtoToEntity(VisitaUsuarioDTO dto)
        {
            return new VisitaUsuario
            {
                UsuarioId = dto.UsuarioId,
                VisitaId = dto.VisitaId,
            };
        }

        public VisitaUsuario FromRequestDtoToEntity(VisitaUsuarioRequestDTO dto)
        {
            return new VisitaUsuario
            {
                UsuarioId = dto.UsuarioId,
                VisitaId = dto.VisitaId
            };
        }

        public IEnumerable<VisitaUsuarioDTO> ToListDTO(IEnumerable<VisitaUsuario> entities)
        {
            return entities.Select(e => FromEntityToDto(e)).ToList();

        }
    }
}
