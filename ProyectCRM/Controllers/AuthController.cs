using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Interfaces;
using ProyectCRM.Service.AuthService;

namespace ProyectCRM.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase, IAuthController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var result = await _authService.LoginAsync(loginRequestDTO);
            if(result == null)
            {
                return Unauthorized("Credenciales inválidas.");
            }
            return Ok(result);
        }
    }
}
