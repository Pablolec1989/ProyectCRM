using FluentValidation;
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
    public class ClienteService : ServiceBase<ClienteDTO, ClienteUpdateCreateDTO, Models.Entities.Cliente>, IClienteService
    {
        public ClienteService(IClienteMapper mapper, 
            IClienteRepository repository, 
            IValidator<Cliente> validator) : base(mapper, repository, validator)
        {
        }
    }
}
