using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class ClienteController : CustomControllerBase<ClienteDTO, ClienteUpdateCreateDTO, Cliente>
    {
        public ClienteController(IClienteService service) : base(service)
        {
        }
    }
}
