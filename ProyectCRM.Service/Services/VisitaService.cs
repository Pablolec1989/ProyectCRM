using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class VisitaService : ServiceBase<VisitaDTO, VisitaRequestDTO, Visita>, IVisitaService
    {
        private readonly IMapper _mapper;
        private readonly IVisitaRepository _repository;
        private readonly IDireccionRepository _direccionRepository;
        private readonly VisitaUsuarioRepository _visitaUsuarioRepository;
        private readonly IValidator<VisitaRequestDTO> _validator;

        public VisitaService(IMapper mapper, 
            IVisitaRepository repository,
            IDireccionRepository direccionRepository,
            VisitaUsuarioRepository visitaUsuarioRepository,
            IValidator<VisitaRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _direccionRepository = direccionRepository;
            _visitaUsuarioRepository = visitaUsuarioRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<VisitaDTO>> GetVisitasByUsuarioAsync(Guid usuarioId)
        {
            var visitas = await _repository.GetVisitasByUsuarioAsync(usuarioId);

            // 2. Mapear a DTO
            return _mapper.Map<IEnumerable<VisitaDTO>>(visitas);
        }
        
        public override async Task<IEnumerable<VisitaDTO>> GetAllAsync()
        {
            var visitas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<VisitaDTO>>(visitas);
        }

        public override async Task<VisitaDTO> CreateAsync(VisitaRequestDTO dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Validar que la dirección pertenece al cliente
            var direccionesCliente = await _direccionRepository.GetDireccionesByClienteIdAsync(dto.ClienteId);
            if (!direccionesCliente.Any(d => d.Id == dto.DireccionId))
                throw new ArgumentException("La dirección no pertenece al cliente.");

            // 1. Crear la visita
            var entityToCreate = _mapper.Map<Visita>(dto);
            var createdEntity = await _repository.CreateAsync(entityToCreate);

            // 2. Crear la relación usuario-visita
            var visitasUsuarios = new VisitasUsuarios
            {
                VisitaId = createdEntity.Id,
                UsuarioId = dto.UsuarioId,
            };
            await _visitaUsuarioRepository.CreateAsync(visitasUsuarios);

            return _mapper.Map<VisitaDTO>(createdEntity);
        }



    }
}
