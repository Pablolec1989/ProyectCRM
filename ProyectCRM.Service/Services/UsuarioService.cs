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

        public UsuarioService(IMapper mapper,
            IUsuarioRepository repository,
            IValidator<UsuarioRequestDTO> validator,
            IConfiguration configuration)
            
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
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
            usuarioToCreate.Password = HashPassword(dto.Password);

            var createdUser = await _repository.CreateAsync(usuarioToCreate);

            var usuarioCompleto = await _repository.GetByIdAsync(createdUser.Id);

            return _mapper.Map<UsuarioDTO>(usuarioCompleto);
        }

        public override async Task<UsuarioDTO> UpdateAsync(Guid id, UsuarioRequestDTO dto)
        {
            await ValidateUsuarioRequest(id, dto);

            if (dto.Password != null)
            {
                dto.Password = HashPassword(dto.Password);
            }

            var userDto = await base.UpdateAsync(id, dto);

            return userDto;
        }

        public async Task<IEnumerable<UsuarioDTO>> SearchUsuarioAsync(UsuarioFilterPaginated filterDTO)
        {
            var usuarios = await _repository.SearchByFilterAsync(filterDTO);
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
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
