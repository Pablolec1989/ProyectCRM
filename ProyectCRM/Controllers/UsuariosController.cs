using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.IdentityModel.Tokens;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.AuthService;
using ProyectCRM.Service.DTOs;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace ProyectCRM.Models.Controllers
{
    [Authorize(Policy = "Admin")]
    public class UsuariosController : CustomControllerBase<UsuarioDTO, UsuarioRequestDTO, Usuario>
    {
        private readonly IUsuarioService _service;

        private const string GetAllCacheTag = "UsuariosCache";
        protected override string CacheTag => GetAllCacheTag;


        public UsuariosController(IUsuarioService service,
            ICacheCleaner cacheCleaner, 
            ILogger<Usuario> logger) : base(service, cacheCleaner, logger)
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


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> SearchUsersAsync([FromQuery] UsuarioFilterPaginated filterDTO)
        {
            var usuarios = await _service.SearchUsuarioAsync(filterDTO);

            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);

        }
        
    }
}
