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

        public async Task<DireccionDetailDTO> GetDireccionCompletoByIdAsync(Guid id)
        {
            var direccion = await _repository.GetDireccionCompletoRepositoryById(id);
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
            //Validar que ClienteId exista
            await _repository.EntityExistsAsync(dto.ClienteId);

            //Validar que TipoDireccionId exista
            await _repository.EntityExistsAsync(dto.TipoDireccionId);

            //Validar que no se este ingresando la misma informacion (Calle, Numero, CodigoPostal) para el mismo ClienteId
            var existingDirecciones = await _repository.GetDireccionesByClienteIdAsync(dto.ClienteId);
            if (existingDirecciones.Any(d => d.Calle.Equals(dto.Calle, StringComparison.OrdinalIgnoreCase)
                && d.Numero == dto.Numero
                && d.CodigoPostal.Equals(dto.CodigoPostal, StringComparison.OrdinalIgnoreCase)
                && (!id.HasValue || d.Id != id.Value)))
            {
                throw new ValidationException("Ya existe una misma dirección para este cliente.");
            }

        }
    }
}
