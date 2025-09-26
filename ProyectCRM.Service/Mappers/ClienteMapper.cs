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
                .Map(dest => dest.Empresa, src => src.Empresa.Adapt<EmpresaDTO>());

            TypeAdapterConfig<Cliente, ClienteDetailDTO>.NewConfig()
                .Map(dest => dest.Empresa, src => src.Empresa.Adapt<EmpresaDTO>())
                .Map(dest => dest.Direcciones, src => src.Direcciones.Adapt<List<DireccionDTO>>())
                .Map(dest => dest.Llamados, src => src.Llamados.Adapt<List<LlamadaDTO>>())
                .Map(dest => dest.Mails, src => src.Mails.Adapt<List<MailDTO>>())
                .Map(dest => dest.Seguimientos, src => src.Seguimientos.Adapt<List<SeguimientoDTO>>())
                .Map(dest => dest.Telefonos, src => src.Telefonos.Adapt<List<TelefonoDTO>>());

            TypeAdapterConfig<ClienteRequestDTO, Cliente>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.EmpresaId, src => src.EmpresaId);

        }
    }
}
