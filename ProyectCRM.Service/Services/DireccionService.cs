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
    public class DireccionService : ServiceBase<DireccionDTO, DireccionRequestDTO, Direccion>, IDireccionService
    {
        private readonly IDireccionRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITipoDireccionRepository _tipoDireccionRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DireccionRequestDTO> _validator;

        public DireccionService(IMapper mapper,
            IDireccionRepository repository,
            IClienteRepository clienteRepository,
            ITipoDireccionRepository tipoDireccionRepository,
            IValidator<DireccionRequestDTO> validator)
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _clienteRepository = clienteRepository;
            _tipoDireccionRepository = tipoDireccionRepository;
            _validator = validator;
        }

        public async Task<DireccionDetailDTO> GetDireccionWithDetailsAsync(Guid id)
        {
            var direccion = await _repository.GetDireccionWithDetailsAsync(id);
            return _mapper.Map<DireccionDetailDTO>(direccion);
        }

        public override async Task<DireccionDTO> CreateAsync(DireccionRequestDTO dto)
        {
            await ValidateDireccionRequest(null, dto);
            return await base.CreateAsync(dto);
        }

        public override async Task<DireccionDTO> UpdateAsync(Guid id, DireccionRequestDTO dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
                throw new KeyNotFoundException($"No se encontró una dirección con el ese Id");

            await ValidateDireccionRequest(id, dto);
            return await base.UpdateAsync(id, dto);
        }

        //Metodo aux
        private async Task ValidateDireccionRequest(Guid? id, DireccionRequestDTO dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //Validar que ClienteId exista
            var cliente = await _clienteRepository.GetByIdAsync(dto.ClienteId);
            if (cliente == null)
                throw new ValidationException("El ClienteId proporcionado no existe.");

            //Validar que TipoDireccionId exista
            var tipoDireccion = await _tipoDireccionRepository.GetByIdAsync(dto.TipoDireccionId);
            if (tipoDireccion == null)
                throw new ValidationException("El TipoDireccionId proporcionado no existe.");

            var existingDirecciones = await _repository.GetDireccionesByClienteIdAsync(dto.ClienteId);
            if (existingDirecciones.Any(d => d.Calle.Equals(dto.Calle, StringComparison.OrdinalIgnoreCase)
                && d.Numero == dto.Numero
                && d.CodigoPostal.Equals(dto.CodigoPostal, StringComparison.OrdinalIgnoreCase)
                && (!id.HasValue || d.Id != id.Value)))
            {
                throw new ValidationException("Ya existe una dirección con la misma calle, número y código postal para este cliente.");
            }

        }
    }
}
