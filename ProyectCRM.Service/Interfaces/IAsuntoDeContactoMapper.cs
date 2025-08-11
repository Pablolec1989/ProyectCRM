using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AsuntoDeContactoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Interfaces
{
    public interface IAsuntoDeContactoMapper : IMapperBase<AsuntoDeContactoDTO, AsuntoDeContactoCreateDTO, AsuntoDeContacto>
    {
    }
}
