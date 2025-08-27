using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class ClienteController : CustomControllerBase<ClienteDTO, ClienteRequestDTO, Cliente>
    {
        public ClienteController(IClienteService service) : base(service)
        {
        }
    }
}
