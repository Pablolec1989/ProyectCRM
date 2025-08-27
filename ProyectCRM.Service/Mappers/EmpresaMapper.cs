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
    public class EmpresaMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Empresa, EmpresaDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.RazonSocial, src => src.RazonSocial)
                .Map(dest => dest.Cuit, src => src.Cuit)
                .Map(dest => dest.Cuil, src => src.Cuil)
                .Map(dest => dest.Rubro, src => src.Rubro)
                .Map(dest => dest.CondicionIva, src => src.CondicionIva)
                .TwoWays();

            TypeAdapterConfig<EmpresaRequestDTO, Empresa>.NewConfig()
                .Map(dest => dest.RazonSocial, src => src.RazonSocial)
                .Map(dest => dest.Cuit, src => src.Cuit)
                .Map(dest => dest.Cuil, src => src.Cuil)
                .Map(dest => dest.RubroId, src => src.RubroId)
                .Map(dest => dest.CondicionIvaId, src => src.CondicionIvaId)
                .TwoWays();
        }
    }

}
