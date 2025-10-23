using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace ProyectCRM.Models.Service.Services
{
    public class UsuarioService : ServiceBase<UsuarioDTO, UsuarioRequestDTO, Usuario>, IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;
        private readonly IValidator<UsuarioRequestDTO> _validator;
        private readonly IConfiguration _configuration;


        public UsuarioService(IMapper mapper,
            IUsuarioRepository repository,
            IValidator<UsuarioRequestDTO> validator,
            IConfiguration configuration)
            
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
            _configuration = configuration;
        }

        public async Task<UsuarioDetailDTO> GetUserDetailAsync(Guid id)
        {
            var usuario = await _repository.GetUserDetailAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException($"No se encontró el usuario con Id {id}");

            var usuarioDetailDTO = _mapper.Map<UsuarioDetailDTO>(usuario);
            return usuarioDetailDTO;
        }

        public override async Task<UsuarioDTO> CreateAsync(UsuarioRequestDTO dto)
        {
            await ValidateUsuarioRequest(null, dto);

            var usuarioToCreate = _mapper.Map<Usuario>(dto);

            var createdUser = await _repository.CreateAsync(usuarioToCreate);

            var usuarioCompleto = await _repository.GetByIdAsync(createdUser.Id);

            return _mapper.Map<UsuarioDTO>(usuarioCompleto);
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var usuario = await _repository.GetUserByApellidoAsync(loginRequestDTO.Apellido);
            var contraseñaValida = ValidarPassword(loginRequestDTO.Password, usuario.Password);
            
            if(usuario == null || !contraseñaValida)
            {
                throw new Exception("Credenciales inválidas");
            }

            var loginResponseDTO = GenerarToken(usuario);
            return loginResponseDTO;
        }

        //Metodos auxiliares
        private async Task ValidateUsuarioRequest(Guid? id, UsuarioRequestDTO dto)
        {
            //Validar AreaId & RolId
            if (dto.AreaId != null && dto.RolId != null)
            {
                if(await _repository.EntityExistsAsync(dto.AreaId.Value))
                    throw new KeyNotFoundException($"El AreaId no existe");

                if(await _repository.EntityExistsAsync(dto.RolId))
                    throw new KeyNotFoundException($"El RolId no existe");
            }
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private bool ValidarPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private LoginResponseDTO GenerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim("apellido", usuario.Apellido),
                new Claim("rol", usuario.Rol?.Nombre ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["KeyJwt"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

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

    }
}
