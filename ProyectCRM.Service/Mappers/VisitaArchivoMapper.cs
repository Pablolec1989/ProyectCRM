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
    public class VisitaArchivoMapper : IVisitaArchivoMapper
    {
        public VisitaArchivoDTO ToDTO(VisitaArchivo entity)
        {
            return new VisitaArchivoDTO
            {
                Id = entity.Id,
                NombreArchivo = entity.NombreArchivo,
                RutaArchivo = entity.RutaArchivo,
                FechaSubida = entity.FechaSubida,
                VisitaId = entity.VisitaId,
                EmpresaId = entity.EmpresaId,
                Empresa = new EmpresaDTO
                {
                    Id = entity.EmpresaId,
                    RazonSocial = entity.Empresa?.RazonSocial
                }
            };
        }

        public VisitaArchivo ToEntity(VisitaArchivoDTO dto)
        {
            return new VisitaArchivo
            {
                Id = dto.Id,
                NombreArchivo = dto.NombreArchivo,
                RutaArchivo = dto.RutaArchivo,
                FechaSubida = dto.FechaSubida
            };
        }

        public VisitaArchivo ToEntity(VisitaArchivoUpdateCreateDTO dto)
        {
            return new VisitaArchivo
            {
                NombreArchivo = dto.NombreArchivo,
                RutaArchivo = dto.RutaArchivo?.FileName,
                FechaSubida = dto.FechaSubida,
                VisitaId = dto.VisitaId,
                EmpresaId = dto.EmpresaId
            };
        }

        public IEnumerable<VisitaArchivoDTO> ToListDTO(IEnumerable<VisitaArchivo> entities)
        {
            return entities.Select(e => ToDTO(e));
        }
    }
}
