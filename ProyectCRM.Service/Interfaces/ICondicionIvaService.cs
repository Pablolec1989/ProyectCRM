using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.IvaCondicionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Interfaces
{
    public interface ICondicionIvaService : IServiceBase<CondicionIvaDTO, CondicionIvaUpdateCreateDTO, CondicionIva>
    {
    }
}
