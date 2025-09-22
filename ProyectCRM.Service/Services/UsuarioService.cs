using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Service.Services
{
    public class UsuarioService : ServiceBase<UsuarioDTO, UsuarioRequestDTO, Usuario>, IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;
        private readonly IAreaRepository _areaRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IValidator<UsuarioRequestDTO> _validator;

        public UsuarioService(IMapper mapper,
            IUsuarioRepository repository,
            IAreaRepository areaRepository,
            IRolRepository rolRepository,
            IValidator<UsuarioRequestDTO> validator)
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _areaRepository = areaRepository;
            _rolRepository = rolRepository;
            _validator = validator;
        }


        public override async Task<UsuarioDTO> CreateAsync(UsuarioRequestDTO dto)
        {
            await ValidateUsuarioRequest(null, dto);
            return await base.CreateAsync(dto);
        }

        public override async Task<UsuarioDTO> UpdateAsync(Guid id, UsuarioRequestDTO dto)
        {
            await ValidateUsuarioRequest(id, dto);
            return await base.UpdateAsync(id, dto);
        }

        private async Task ValidateUsuarioRequest(Guid? id, UsuarioRequestDTO dto)
        {
            //Validar modelo
            var validationResult = _validator.Validate(dto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //Validar si el usuario ya existe

            await UsuarioExists(dto);

            await AreaExists(dto.AreaId);

            await RolExists(dto.RolId);

        }
        private async Task UsuarioExists(UsuarioRequestDTO dto)
        {
            var usuarioExists = await _repository.GetByNombreYApellidoAsync(dto.Nombre, dto.Apellido);
            if (usuarioExists)
                throw new ValidationException($"El usuario {dto.Nombre} {dto.Apellido} ya existe.");
        }
        private async Task AreaExists(Guid areaId)
        {
            var areaExists = await _areaRepository.GetByIdAsync(areaId);
            if (areaExists == null)
                throw new ValidationException($"El area no existe.");
        }
        private async Task RolExists(Guid rolId)
        {
            var rolExists = await _rolRepository.GetByIdAsync(rolId);
            if (rolExists == null)
                throw new ValidationException($"El rol no existe.");
        }

    }
}
