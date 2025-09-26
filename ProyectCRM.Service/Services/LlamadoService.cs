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
            await _repository.EntityExistsAsync(dto.ClienteId);

            //Validar existencia de UsuarioId
            await _repository.EntityExistsAsync(dto.UsuarioId);

            //Validar existencia de AreaId
            await _repository.EntityExistsAsync(dto.AreaId);

            //Validar existencia de AsuntoDeContactoId
            await _repository.EntityExistsAsync(dto.AsuntoDeContactoId);


        }
    }
}
