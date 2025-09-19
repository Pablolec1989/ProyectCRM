using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Service.Services
{
    public class UsuarioService : ServiceBase<UsuarioDTO, UsuarioRegisterDTO, Usuario>, IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;
        private readonly IValidator<UsuarioRegisterDTO> _validator;

        public UsuarioService(IMapper mapper,
            IUsuarioRepository repository,
            IValidator<UsuarioRegisterDTO> validator)
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> LoginAsync(UsuarioLoginDTO dto)
        {
            var usuarioExiste = await _repository.GetUserAsync(dto.Usuario);
            var passwordHash = HashPassword(dto.Password);

            if(usuarioExiste == null || !VerifyPassword(dto.Password, usuarioExiste.Password))
            {
                return false;
            }
            return true;
        }

        public async Task<UsuarioDTO> RegisterUserAsync(UsuarioRegisterDTO dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var usuario = new Usuario()
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Password = HashPassword(dto.Password),
                RolId = dto.RolId
            };

            var usuarioCreado = await _repository.CreateAsync(usuario);
            return _mapper.Map<UsuarioDTO>(usuarioCreado);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        }
    }
}
