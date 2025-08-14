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
    public class CondicionIvaService : ServiceBase<CondicionIvaDTO, CondicionIvaUpdateCreateDTO, CondicionIva>, ICondicionIvaService
    {
        public CondicionIvaService(ICondicionIvaMapper mapper, ICondicionIvaRepository repository, IValidator<CondicionIva> validator) 
            : base(mapper, repository, validator)
        {
            
        }
    }
}
