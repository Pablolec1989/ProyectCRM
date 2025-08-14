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
    public class RubroService : ServiceBase<RubroDTO, RubroUpdateCreateDTO, Rubro>, IRubroService
    {
        public RubroService(IMapperBase<RubroDTO, RubroUpdateCreateDTO, Rubro> mapper, 
            IRubroRepository repository, IValidator<Rubro> validator) 
            : base(mapper, repository, validator)
        {
            
        }
    }
}
