using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.TipoTelefonoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Interfaces
{
    public interface ITipoTelefonoService : IServiceBase<TipoTelefonoDTO, TipoTelefonoCreateDTO, TipoTelefono>
    {
    }
}
