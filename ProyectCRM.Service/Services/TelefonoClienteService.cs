using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class TelefonoClienteService : ServiceBase<TelefonoClienteDTO, TelefonoClienteRequestDTO, TelefonosCliente>, ITelefonoClienteService
    {
        public TelefonoClienteService(IMapper mapper, 
            ITelefonoClienteRepository repository, 
            IValidator<TelefonoClienteRequestDTO> validator)
            : base(mapper, repository, validator)
        {
            
        }
    }
}
