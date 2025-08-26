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
    public class ArchivoMapper : IArchivoMapper
    {
        public ArchivoDTO FromEntityToDto(Archivo entity)
        {
            return new ArchivoDTO
            {
                Id = entity.Id,
                NombreArchivo = entity.NombreArchivo,
                RutaArchivo = entity.RutaArchivo,
                FechaSubida = entity.FechaSubida,
                VisitaId = entity.VisitaId,
                EmpresaId = entity.EmpresaId,
            };
        }
        public Archivo FromRequestDtoToEntity(ArchivoRequestDTO dto)
        {
            return new Archivo
            {
                NombreArchivo = dto.NombreArchivo,
                RutaArchivo = dto.RutaArchivo,
                FechaSubida = dto.FechaSubida,
                VisitaId = dto.VisitaId,
                EmpresaId = dto.EmpresaId
            };
        }

        public IEnumerable<ArchivoDTO> ToListDTO(IEnumerable<Archivo> entities)
        {
            return entities.Select(e => FromEntityToDto(e));
        }
    }
}
