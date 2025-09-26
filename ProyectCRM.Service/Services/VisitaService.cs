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

        public async Task<VisitaDetailDTO> GetVisitaCompletoByIdAsync(Guid id)
        {
            var visita = await _repository.GetVisitaCompletoByIdAsync(id);
            if(visita == null)
            {
                throw new KeyNotFoundException("Visita no encontrada.");
            }
            var visitaDetailDTO = _mapper.Map<VisitaDetailDTO>(visita);
            return visitaDetailDTO;
        }

        public override async Task<VisitaDTO> CreateAsync(VisitaRequestDTO dto)
        {

            await ValidateVisitaRequest(null, dto);
            var visitatoCreate = _mapper.Map<Visita>(dto);
            var createdVisita = await _repository.CreateAsync(visitatoCreate);
            var visitaCompleta = await _repository.GetByIdAsync(createdVisita.Id);
            return _mapper.Map<VisitaDTO>(visitaCompleta);

        }

        public override async Task<VisitaDTO> UpdateAsync(Guid id, VisitaRequestDTO dto)
        {
            //Validar que dto.ClienteId no cambie
            var existingVisita = await _repository.GetByIdAsync(id);
            if (existingVisita == null)
            {
                throw new KeyNotFoundException("Visita no encontrada.");
            }
            
            if (existingVisita.ClienteId != dto.ClienteId)
            {
                throw new ValidationException("No se puede cambiar el ClienteId de una visita existente.");
            }

            await ValidateVisitaRequest(id,dto);
            return await base.UpdateAsync(id, dto);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var visita = await _repository.GetByIdAsync(id);
            if (visita == null)
            {
                throw new KeyNotFoundException("Visita no encontrada.");
            }
            // Elimina las asociaciones en VisitaUsuario
            await _visitaUsuarioRepository.DeleteByVisitaIdAsync(id);
            return await _repository.DeleteAsync(id);
        }

        //Metodo auxiliar
        private async Task ValidateVisitaRequest(Guid? id, VisitaRequestDTO dto)
        {
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

            var createdVisita = await base.CreateAsync(dto);

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
        }

    }
}
