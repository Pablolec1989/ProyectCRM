using FluentValidation;
using MapsterMapper;
using ProyectCRM.Data;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class AreaService : ServiceBase<AreaDTO, AreaRequestDTO, Area>, IAreaService
    {
        public AreaService(IMapper mapper,
            IAreaRepository repository, 
            IValidator<AreaRequestDTO> validator )
            : base(mapper, repository, validator)
        {
        }
    }
}