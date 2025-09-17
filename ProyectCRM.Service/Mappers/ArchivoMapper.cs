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
    public class ArchivoMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Archivo, ArchivoDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.NombreArchivo, src => src.NombreArchivo)
                .Map(dest => dest.RutaArchivo, src => src.RutaArchivo)
                .Map(dest => dest.FechaSubida, src => src.FechaSubida);

            TypeAdapterConfig<ArchivoRequestDTO, Archivo>.NewConfig()
                .Map(dest => dest.NombreArchivo, src => src.NombreArchivo)
                .Map(dest => dest.RutaArchivo, src => src.RutaArchivo)
                .Map(dest => dest.VisitaId, src => src.VisitaId);

        }
    }
}
