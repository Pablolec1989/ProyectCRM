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
                .Map(dest => dest.Direcciones, src => src.Direcciones != null ? src.Direcciones.Adapt<List<DireccionDTO>>() : null)
                .Map(dest => dest.Llamados, src => src.Llamados != null ? src.Llamados.Adapt<List<LlamadaDTO>>() : null)
                .Map(dest => dest.Mails, src => src.Mails != null ? src.Mails.Adapt<List<MailDTO>>() : null)
                .Map(dest => dest.Seguimientos, src => src.Seguimientos != null ? src.Seguimientos.Adapt<List<SeguimientoDTO>>() : null)
                .Map(dest => dest.Telefonos, src => src.Telefonos != null ? src.Telefonos.Adapt<List<TelefonoDTO>>() : null)
                .Map(dest => dest.Visitas, src => src.Visitas != null ? src.Visitas.Adapt<VisitaDTO>() : null);

            TypeAdapterConfig<ClienteRequestDTO, Cliente>.NewConfig()
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.Apellido, src => src.Apellido)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.EmpresaId, src => src.EmpresaId);

        }
    }
}
