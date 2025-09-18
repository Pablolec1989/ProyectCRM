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
    public class TelefonoService : ServiceBase<TelefonoDTO, TelefonoRequestDTO, Telefonos>, ITelefonoService
    {
        public TelefonoService(IMapper mapper, 
            ITelefonoRepository repository, 
            IValidator<TelefonoRequestDTO> validator)
            : base(mapper, repository, validator)
        {
            
        }
    }
}
