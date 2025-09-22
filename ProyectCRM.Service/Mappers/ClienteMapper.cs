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
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.EmpresaRazonSocial, src => src.Empresa.RazonSocial != null ? src.Empresa.RazonSocial : null);

            TypeAdapterConfig<Cliente, ClienteDetailDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.EmpresaRazonSocial, src => src.Empresa.RazonSocial != null ? src.Empresa.RazonSocial : null)
                .Map(dest => dest.Direcciones, src => src.Direcciones)
                .Map(dest => dest.Llamados, src => src.Llamados)
                .Map(dest => dest.Mails, src => src.Mails)
                .Map(dest => dest.Seguimientos, src => src.Seguimientos)
                .Map(dest => dest.Telefonos, src => src.Telefonos)
                .Map(dest => dest.Visitas, src => src.Visitas);


            TypeAdapterConfig<ClienteRequestDTO, Cliente>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.EmpresaId, src => src.EmpresaId);

        }
    }
}
