using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;
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
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly VisitaUsuarioRepository _visitaUsuarioRepository;
        private readonly IValidator<VisitaRequestDTO> _validator;

        public VisitaService(IMapper mapper, 
            IVisitaRepository repository,
            IDireccionRepository direccionRepository,
            IUsuarioRepository usuarioRepository,
            VisitaUsuarioRepository visitaUsuarioRepository,
            IValidator<VisitaRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _direccionRepository = direccionRepository;
            _usuarioRepository = usuarioRepository;
            _visitaUsuarioRepository = visitaUsuarioRepository;
            _validator = validator;
        }

        public async Task<VisitaDetailDTO> GetByIdWithRelatedDataAsync(Guid id)
        {
            var visita = await _repository.GetByIdWithRelatedDataAsync(id);
            var visitaDetailDTO = new VisitaDetailDTO()
            {
                Id = visita.Id,
                Observaciones = visita.Observaciones,
                Cliente = visita.Cliente != null ? _mapper.Map<ClienteDTO>(visita.Cliente) : null,
                Direccion = visita.Direccion != null ? _mapper.Map<DireccionDTO>(visita.Direccion) : null,
                Usuarios = visita.VisitasUsuarios != null ? visita.VisitasUsuarios
                    .Select(vu => vu.Usuario != null ? _mapper.Map<UsuarioDTO>(vu.Usuario) : null)
                    .ToList() : new List<UsuarioDTO>(),
                Archivos = visita.Archivos != null ? visita.Archivos
                    .Select(a => _mapper.Map<ArchivoDTO>(a))
                    .ToList() : new List<ArchivoDTO>(),
                FechaProgramada = visita.FechaProgramada,
                FechaRealizada = visita.FechaRealizada
            };
            return visitaDetailDTO;
        }

        public override async Task<VisitaDTO> CreateAsync(VisitaRequestDTO dto)
        {
            //Valida el dto
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            //valida que DireccionId exista y corresponda al Cliente
            var direccion = await _direccionRepository.GetByIdAsync(dto.DireccionId);
            if (direccion == null || direccion.ClienteId != dto.ClienteId)
            {
                throw new ValidationException("La dirección no existe o no corresponde al cliente proporcionado.");
            }

            // Validación de la existencia de UsuariosIds
            if (dto.UsuariosIds != null && dto.UsuariosIds.Any())
            {
                var existingUserIds = await _usuarioRepository.GetExistingUserIdsAsync(dto.UsuariosIds);
                if (existingUserIds.Count != dto.UsuariosIds.Count)
                {
                    var nonExistingUserIds = dto.UsuariosIds.Except(existingUserIds);
                    throw new ValidationException($"Intentas asociar usuarios que no existen");
                }
            }

            var visitaToCreate = _mapper.Map<Visita>(dto);
            var createdVisita = await _repository.CreateAsync(visitaToCreate);

            // Si hay UsuariosIds, crea las entradas en VisitaUsuario
            if (dto.UsuariosIds != null && dto.UsuariosIds.Any())
            {
                // Mapea la lista de IDs a una colección de entidades VisitasUsuarios en memoria
                var visitasUsuarios = dto.UsuariosIds
                    .Select(usuarioId => new VisitaUsuario
                {
                    VisitaId = createdVisita.Id,
                    UsuarioId = usuarioId

                }).ToList();

                await _visitaUsuarioRepository.AddRangeAsync(visitasUsuarios);
            }
            return _mapper.Map<VisitaDTO>(createdVisita);

        }

        public override async Task<IEnumerable<VisitaDTO>> GetAllAsync()
        {
            var visitas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<VisitaDTO>>(visitas);
        }

    }
}
