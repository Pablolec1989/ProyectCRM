using FluentValidation;
using Mapster;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using System.Collections.Generic;

namespace ProyectCRM.Models.Service.Services
{
    public class UsuarioService : ServiceBase<UsuarioDTO, UsuarioRequestDTO, Usuario>, IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;
        private readonly IValidator<UsuarioRequestDTO> _validator;

        public UsuarioService(IMapper mapper,
            IUsuarioRepository repository,
            IValidator<UsuarioRequestDTO> validator)
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<UsuarioDetailDTO> GetUsuarioCompletoByIdAsync(Guid id)
        {
            var usuario = await _repository.GetUsuarioCompletoByIdAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException($"No se encontró el usuario con Id {id}");

            var usuarioDetailDTO = _mapper.Map<UsuarioDetailDTO>(usuario);
            return usuarioDetailDTO;
        }

        public override async Task<UsuarioDTO> CreateAsync(UsuarioRequestDTO dto)
        {
            await ValidateUsuarioRequest(null, dto);

            var usuarioToCreate = _mapper.Map<Usuario>(dto);

            // Paso 2: Crear el usuario en el repositorio
            var createdUser = await _repository.CreateAsync(usuarioToCreate);

            // Paso 3: Obtener el usuario completo con sus datos relacionados (Rol y Area)
            var usuarioCompleto = await _repository.GetByIdAsync(createdUser.Id);

            // Paso 4: Mapear la entidad completa a un DTO para la respuesta
            return _mapper.Map<UsuarioDTO>(usuarioCompleto);
        }

        public override async Task<UsuarioDTO> UpdateAsync(Guid id, UsuarioRequestDTO dto)
        {
            await ValidateUsuarioRequest(id, dto);
            return await base.UpdateAsync(id, dto);
        }

        //Metodos auxiliares
        private async Task ValidateUsuarioRequest(Guid? id, UsuarioRequestDTO dto)
        {
            //Validar AreaId
            if (dto.AreaId != null)
            {
                if(await _repository.EntityExistsAsync(dto.AreaId.Value))
                    throw new KeyNotFoundException($"El AreaId no existe");
            }
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
