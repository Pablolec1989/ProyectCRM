using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class LlamadoService : ServiceBase<LlamadaDTO, LlamadaRequestDTO, Llamado>, ILlamadoService
    {
        private readonly IMapper _mapper;
        private readonly ILlamadoRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IAsuntoDeContactoRepository _asuntoDeContactoRepository;


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
            _clienteRepository = clienteRepository;
            _usuarioRepository = usuarioRepository;
            _areaRepository = areaRepository;
            _asuntoDeContactoRepository = asuntoDeContactoRepository;
            _validator = validator;
        }

        public override async Task<IEnumerable<LlamadaDTO>> GetAllAsync()
        {
            var llamados = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<LlamadaDTO>>(llamados);
        }

        public async Task<LlamadaDetailDTO> GetByIdWithRelatedDataAsync(Guid id)
        {
            var llamado = await _repository.GetByIdWithRelatedDataAsync(id);
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
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //Validar existencia de ClienteId
            var clienteExists = await _clienteRepository.GetByIdAsync(dto.ClienteId);
            if (clienteExists == null)
               throw new KeyNotFoundException($"Cliente with ID {dto.ClienteId} not found.");

            //Validar existencia de UsuarioId
            var usuarioExists = await _usuarioRepository.GetByIdAsync(dto.UsuarioId);
            if (usuarioExists == null)
                throw new KeyNotFoundException($"Usuario with ID {dto.UsuarioId} not found.");
            
            //Validar existencia de AreaId
            if (dto.AreaId != Guid.Empty)
            {
                var areaExists = await _areaRepository.GetByIdAsync(dto.AreaId);
                if (areaExists == null)
                    throw new KeyNotFoundException($"Area with ID {dto.AreaId} not found.");
            }

            //Validar existencia de AsuntoDeContactoId
            var asuntoExists = await _asuntoDeContactoRepository.GetByIdAsync(dto.AsuntoDeContactoId);
            if (asuntoExists == null)
                throw new KeyNotFoundException($"AsuntoDeContacto with ID {dto.AsuntoDeContactoId} not found.");


        }
    }
}
