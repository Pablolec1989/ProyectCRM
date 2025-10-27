using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class SeguimientoService : ServiceBase<SeguimientoDTO, SeguimientoRequestDTO, Seguimiento>, ISeguimientoService
    {
        private readonly IMapper _mapper;
        private readonly ISeguimientoRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<SeguimientoRequestDTO> _validator;

        public SeguimientoService(IMapper mapper, 
            ISeguimientoRepository repository,
            IClienteRepository clienteRepository,
            IUsuarioRepository usuarioRepository,
            IValidator<SeguimientoRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _clienteRepository = clienteRepository;
            _usuarioRepository = usuarioRepository;
            _validator = validator;
        }

        public async Task<SeguimientoDetailDTO> GetSeguimientoCompletoByIdAsync(Guid id)
        {
            var seguimiento = await _repository.GetSeguimientoCompletoRepositoryByIdAsync(id);
            return _mapper.Map<SeguimientoDetailDTO>(seguimiento);
        }

        public override async Task<SeguimientoDTO> CreateAsync(SeguimientoRequestDTO dto)
        {
            await ValidateSeguimientoRequest(null, dto);
            return await base.CreateAsync(dto);
        }

        public override async Task<SeguimientoDTO> UpdateAsync(Guid id, SeguimientoRequestDTO dto)
        {
            await ValidateSeguimientoRequest(id, dto);
            return await base.UpdateAsync(id, dto);
        }

        //Metodo aux
        private async Task ValidateSeguimientoRequest(Guid? id, SeguimientoRequestDTO dto)
        {
            //Validar que el ClienteId exista
            await _repository.EntityExistsAsync(dto.ClienteId);

            //Validar que el UsuarioId exista
            await _repository.EntityExistsAsync(dto.UsuarioId);

            if(dto.AreaId != null)
            {
                //Validar que el AreaId exista
                await _repository.EntityExistsAsync(dto.AreaId.Value);
            }

        }
    }
}
