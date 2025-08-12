using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.DireccionDTO;
using ProyectCRM.Service.DTOs.DireccionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Interfaces
{
    public interface IDireccionService : IServiceBase<DireccionDTO, DireccionCreateUpdateDTO, Direccion>
    {
    }
}
