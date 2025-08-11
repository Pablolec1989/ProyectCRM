using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AreaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Interfaces
{
    public interface IAreaMapper : IMapperBase<AreaDTO, AreaCreateDTO, Area>
    {
    }
}
