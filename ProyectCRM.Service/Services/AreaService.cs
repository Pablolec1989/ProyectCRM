using ProyectCRM.Data;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class AreaService : ServiceBase<AreaDTO, AreaCreateDTO, Area>, IAreaService
    {
        public AreaService(IMapperBase<AreaDTO, AreaCreateDTO, Area> mapper,
            IAreaRepository repository)
            : base(mapper, repository)
        {
        }
    }
}