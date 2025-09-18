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
    public class DireccionMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Direccion, DireccionDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Calle, src => src.Calle)
                .Map(dest => dest.Numero, src => src.Numero)
                .Map(dest => dest.Ciudad, src => src.Ciudad)
                .Map(dest => dest.CodigoPostal, src => src.CodigoPostal)
                .Map(dest => dest.Provincia, src => src.Provincia)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.Cliente, src => src.Cliente)
                .Map(dest => dest.TipoDireccionId, src => src.TipoDireccionId)
                .Map(dest => dest.TipoDireccion, src => src.TipoDireccion)
                .TwoWays();

            TypeAdapterConfig<DireccionRequestDTO, Direccion>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Calle, src => src.Calle)
                .Map(dest => dest.Numero, src => src.Numero)
                .Map(dest => dest.Ciudad, src => src.Ciudad)
                .Map(dest => dest.CodigoPostal, src => src.CodigoPostal)
                .Map(dest => dest.Provincia, src => src.Provincia)
                .Map(dest => dest.ClienteId, src => src.ClienteId)
                .Map(dest => dest.TipoDireccionId, src => src.TipoDireccionId)
                .TwoWays();
        }
    }
}
