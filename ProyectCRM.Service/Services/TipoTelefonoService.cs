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
    public class TipoTelefonoService : ServiceBase<TipoTelefonoDTO, TipoTelefonoRequestDTO, TiposTelefono>, ITipoTelefonoService
    {
        public TipoTelefonoService(IMapper mapper, 
            ITipoTelefonoRepository repository, 
            IValidator<TipoTelefonoRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
        }
    }
}
