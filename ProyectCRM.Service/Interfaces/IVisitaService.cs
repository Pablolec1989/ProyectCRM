using Microsoft.AspNetCore.Http;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Interfaces
{
    public interface IVisitaService : IServiceBase<VisitaDTO, VisitaRequestDTO, Visita>
    {
        Task<IEnumerable<VisitaDTO>> GetVisitasByUsuarioAsync(Guid usuarioId);
    }
}
