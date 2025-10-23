using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Service.Services
{
    public class LlamadoService : ServiceBase<LlamadaDTO, LlamadaRequestDTO, Llamado>, ILlamadoService
    {
        private readonly IMapper _mapper;
        private readonly ILlamadoRepository _repository;
        private readonly IValidator<LlamadaRequestDTO> _validator;

        public LlamadoService(IMapper mapper, 
            ILlamadoRepository repository, 
            IClienteRepository clienteRepository,
            IUsuarioRepository usuarioRepository,
            IAreaRepository areaRepository,
            IAsuntoDeContactoRepository asuntoDeContactoRepository,
            IValidator<LlamadaRequestDTO> validator)
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public override async Task<IEnumerable<LlamadaDTO>> SearchPaginated(PaginationDTO pagination)
        {
            var llamados = await _repository.SearchPaginated(pagination);
            return _mapper.Map<IEnumerable<LlamadaDTO>>(llamados);
        }

        public async Task<LlamadaDetailDTO> GetLlamadaCompletoByIdAsync(Guid id)
        {
            var llamado = await _repository.GetLlamadaCompletoByIdAsync(id);
            return _mapper.Map<LlamadaDetailDTO>(llamado);
        }

        public override async Task<LlamadaDTO> CreateAsync(LlamadaRequestDTO dto)
        {
            await ValidateLlamadoRequestDTO(null, dto);
            return await base.CreateAsync(dto);
        }

        public override async Task<LlamadaDTO> UpdateAsync(Guid id, LlamadaRequestDTO dto)
        {
            await ValidateLlamadoRequestDTO(id, dto);
            return await base.UpdateAsync(id, dto);
        }

        private async Task ValidateLlamadoRequestDTO(Guid? id, LlamadaRequestDTO dto)
        {

            //Validar existencia de ClienteId
            if (await _repository.EntityExistsAsync(dto.ClienteId))
                throw new KeyNotFoundException($"El ClienteId no existe");

            //Validar existencia de UsuarioId
            if(await _repository.EntityExistsAsync(dto.UsuarioId))
                throw new KeyNotFoundException($"El UsuarioId no existe");

            //Validar existencia de AreaId
            if(await _repository.EntityExistsAsync(dto.AreaId))
                throw new KeyNotFoundException($"El AreaId no existe");

            //Validar existencia de AsuntoDeContactoId
            if(await _repository.EntityExistsAsync(dto.AsuntoDeContactoId))
                throw new KeyNotFoundException($"El AsuntoDeContactoId no existe");

        }
    }
}
