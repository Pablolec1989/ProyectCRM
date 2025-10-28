using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Service.AuthService;

namespace ProyectCRM.Interfaces
{
    public interface IAuthController { 
        Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginRequestDTO);
    }
}
