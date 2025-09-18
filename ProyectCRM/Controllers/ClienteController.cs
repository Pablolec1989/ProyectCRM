using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class ClienteController : CustomControllerBase<ClienteDTO, ClienteRequestDTO, Cliente>
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service) : base(service)
        {
            _service = service;
        }

    }
}
