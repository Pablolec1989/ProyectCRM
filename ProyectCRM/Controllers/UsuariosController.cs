using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ProyectCRM.Models.Controllers
{
    public class UsuariosController : CustomControllerBase<UsuarioDTO, UsuarioRegisterDTO, Usuario>
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> LoginAsync(UsuarioLoginDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            return Ok(await _service.LoginAsync(dto));
        }

        [HttpPost("register")]
        public override async Task<ActionResult<UsuarioDTO>> CreateAsync(UsuarioRegisterDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var userRegistered = await _service.RegisterUserAsync(dto);
            return Ok(userRegistered);

        }
    }
}
