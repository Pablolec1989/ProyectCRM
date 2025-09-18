using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class DireccionController : CustomControllerBase<DireccionDTO, DireccionRequestDTO, Direccion>
    {
        private readonly IDireccionService _service;

        public DireccionController(IDireccionService service)
            : base(service)
        {
            _service = service;
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetDireccionesByClienteId(Guid clienteId)
        {
            var direcciones = await _service.GetDireccionesByClienteIdAsync(clienteId);
            return Ok(direcciones);
        }

    }
}

