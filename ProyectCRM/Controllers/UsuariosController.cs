using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ProyectCRM.Models.Controllers
{
    public class UsuariosController : CustomControllerBase<UsuarioDTO, UsuarioRequestDTO, Usuario>
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<UsuarioDetailDTO>> GetUsuarioCompletoByIdAsync([FromRoute][Required] Guid id)
        {
            var usuarioDetail = await _service.GetUsuarioCompletoByIdAsync(id);
            if (usuarioDetail == null)
            {
                return NotFound();
            }
            return Ok(usuarioDetail);
        }


    }
}
