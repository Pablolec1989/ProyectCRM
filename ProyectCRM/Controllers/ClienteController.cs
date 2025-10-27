using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class ClienteController : CustomControllerBase<ClienteDTO, ClienteRequestDTO, Cliente>
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service, 
            ICacheCleaner cacheCleaner, 
            ILogger<Cliente> logger) : base(service, cacheCleaner, logger)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetClienteDetailAsync(Guid id)
        {
            var cliente = await _service.GetClienteDetailAsync(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<ClienteDTO>> SearchClientesAsync([FromQuery] ClienteFilterPaginated filter)
        {
            return await _service.SearchClientesAsync(filter);
        }

    }
}
