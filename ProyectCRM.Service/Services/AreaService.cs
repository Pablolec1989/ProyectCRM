using ProyectCRM.Data.Repositories;
using ProyectCRM.Models;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class AreaService : ServiceBase<AreaDTO, Area>, IAreaService
    {
        private readonly IAreaMapper _areaMapper;
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaMapper areaMapper, IAreaRepository areaRepository) 
            : base(areaMapper, areaRepository)
        {
            _areaMapper = areaMapper;
            _areaRepository = areaRepository;
        }
    }
}
