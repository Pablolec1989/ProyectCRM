using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

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
        public async Task<ActionResult<UsuarioDetailDTO>> GetUserDetailAsync([FromRoute][Required] Guid id)
        {
            var usuarioDetail = await _service.GetUserDetailAsync(id);
            if (usuarioDetail == null)
            {
                return NotFound();
            }
            return Ok(usuarioDetail);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> LoginAsync([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginResponse = await _service.LoginAsync(loginRequestDTO);
            if (loginResponse == null)
            {
                return Unauthorized("Credenciales inválidas.");
            }
            return Ok(loginResponse);


        }
    }
}
