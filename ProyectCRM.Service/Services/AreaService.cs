using ProyectCRM.Data.Repositories;
using ProyectCRM.Models;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class AreaService : ServiceBase<AreaDTO, Area>, IAreaService
    {
        public AreaService(IAreaMapper areaMapper, IAreaRepository areaRepository) 
            : base(areaMapper, areaRepository)
        {

        }
    }
}
