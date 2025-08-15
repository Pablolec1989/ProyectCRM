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
        public VisitaUsuarioDTO ToDTO(VisitaUsuario entity)
        {
            return new VisitaUsuarioDTO
            {
                UsuarioId = entity.UsuarioId,
                VisitaId = entity.VisitaId,
            };
        }

        public VisitaUsuario ToEntity(VisitaUsuarioDTO dto)
        {
            return new VisitaUsuario
            {
                UsuarioId = dto.UsuarioId,
                VisitaId = dto.VisitaId,
            };
        }

        public VisitaUsuario ToEntity(VisitaUsuarioUpdateCreateDTO dto)
        {
            return new VisitaUsuario
            {
                UsuarioId = dto.UsuarioId,
                VisitaId = dto.VisitaId
            };
        }

        public IEnumerable<VisitaUsuarioDTO> ToListDTO(IEnumerable<VisitaUsuario> entities)
        {
            return entities.Select(e => ToDTO(e)).ToList();

        }
    }
}
