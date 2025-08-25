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
    public class RubroService : ServiceBase<RubroDTO, RubroRequestDTO, Rubro>, IRubroService
    {
        public RubroService(IMapperBase<RubroDTO, RubroRequestDTO, Rubro> mapper, 
            IRubroRepository repository, IValidator<RubroRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
            
        }
    }
}
