using FluentValidation;
using ProyectCRM.Data;
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
    public class AreaService : ServiceBase<AreaDTO, AreaUpdateCreateDTO, Area>, IAreaService
    {
        public AreaService(IMapperBase<AreaDTO, AreaUpdateCreateDTO, Area> mapper,
            IAreaRepository repository, IValidator<Area> validator)
            : base(mapper, repository, validator)
        {
        }
    }
}