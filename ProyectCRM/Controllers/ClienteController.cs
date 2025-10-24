using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class ClienteController : CustomControllerBase<ClienteDTO, ClienteRequestDTO, Cliente>
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service, IOutputCacheStore outputCacheStore) : base(service, outputCacheStore)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetClienteDetailAsync(Guid id)
        {
            var cliente = await _service.GetClienteCompletoByIdAsync(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

    }
}
