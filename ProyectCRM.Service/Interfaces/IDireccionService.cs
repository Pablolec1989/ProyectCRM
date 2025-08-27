using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Interfaces
{
    public interface IDireccionService : IServiceBase<DireccionDTO, DireccionRequestDTO, Direccion>
    {
    }
}
