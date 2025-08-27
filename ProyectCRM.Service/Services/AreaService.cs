using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
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