using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        public override async Task<UsuarioDTO> CreateAsync(UsuarioRequestDTO dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var usuario = new Usuario
            {
                Apellido = dto.Apellido,
                Password = HashPassword(dto.Password),
                RolId = dto.RolId
            };

            var user = await _repository.CreateAsync(usuario);
            return _mapper.Map<UsuarioDTO>(user);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
