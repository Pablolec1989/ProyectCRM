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
    public class ClienteMapper
    {
        public void RegisterMappings()
        {
            TypeAdapterConfig<Cliente, ClienteDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Email, src => src.Email);


            TypeAdapterConfig<ClienteRequestDTO, Cliente>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.EmpresaId, src => src.EmpresaId);

        }
    }
}
