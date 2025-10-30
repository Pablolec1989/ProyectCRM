using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Interfaces
{
    public interface IClienteService : IServiceBase<ClienteDTO, ClienteRequestDTO, Cliente>
    {
        Task<ClienteDetailDTO> GetClienteDetailAsync(Guid id);
        Task<IEnumerable<ClienteDTO>> SearchClientesAsync(ClienteFilterPaginatedDTO filter);
    }
}
