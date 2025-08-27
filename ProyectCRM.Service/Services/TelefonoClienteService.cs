using FluentValidation;
using MapsterMapper;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class TelefonoClienteService : ServiceBase<TelefonoClienteDTO, TelefonoClienteRequestDTO, TelefonoCliente>, ITelefonoClienteService
    {
        public TelefonoClienteService(IMapper mapper, 
            ITelefonoClienteRepository repository, 
            IValidator<TelefonoClienteRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
        }
    }
}
