using FluentValidation;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;
        private readonly IValidator<UsuarioRequestDTO> _validator;
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper,
            IUsuarioRepository repository,
            IValidator<UsuarioRequestDTO> validator,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var usuario = await _repository.GetUserByApellidoAsync(loginRequestDTO.Apellido);
            if(usuario is null)
            {
                throw new UnauthorizedAccessException("Credenciales inválidas.");
            }
            
            var contraseñaValida = ValidatePassword(loginRequestDTO.Password, usuario.Password);

            if (usuario == null || !contraseñaValida)
            {
                throw new Exception("Credenciales inválidas");
            }

            var loginResponseDTO = GenerarToken(usuario);
            return loginResponseDTO;
        }
        private LoginResponseDTO GenerarToken(Usuario usuario)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}")
            };

            // agrega claim de rol sólo si existe
            if (!string.IsNullOrWhiteSpace(usuario.Rol?.Nombre))
            {
                claims.Add(new Claim(ClaimTypes.Role, usuario.Rol.Nombre));
            }

            var keyString = _configuration["KeyJwt"];
            if (string.IsNullOrWhiteSpace(keyString))
                throw new InvalidOperationException("La clave JWT (KeyJwt) no está configurada.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Recomendación: expiración corta + refresh tokens; usar 1 hora como ejemplo
            var expiration = DateTime.UtcNow.AddHours(1);

            var tokenSecurity = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenSecurity);
            return new LoginResponseDTO
            {
                Token = token,
                FechaExpiracion = expiration
            };
        }

        //Metodos auxiliares
        private async Task ValidateUsuarioRequest(Guid? id, UsuarioRequestDTO dto)
        {
            //Validar AreaId & RolId
            if (dto.AreaId != null && dto.RolId != null)
            {
                if (await _repository.EntityExistsAsync(dto.AreaId.Value))
                    throw new KeyNotFoundException($"El AreaId no existe");

                if (await _repository.EntityExistsAsync(dto.RolId))
                    throw new KeyNotFoundException($"El RolId no existe");
            }
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private bool ValidatePassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

    }
}
