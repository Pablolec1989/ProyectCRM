using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class TelefonoService : ServiceBase<TelefonoDTO, TelefonoRequestDTO, Telefono>, ITelefonoService
    {
        private readonly IMapper _mapper;
        private readonly ITelefonoRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITipoTelefonoRepository _tipoTelefonoRepository;
        private readonly IValidator<TelefonoRequestDTO> _validator;

        public TelefonoService(IMapper mapper, 
            ITelefonoRepository repository,
            IClienteRepository clienteRepository,
            ITipoTelefonoRepository tipoTelefonoRepository,
            IValidator<TelefonoRequestDTO> validator)
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _clienteRepository = clienteRepository;
            _tipoTelefonoRepository = tipoTelefonoRepository;
            _validator = validator;
        }

        public override async Task<TelefonoDTO> CreateAsync(TelefonoRequestDTO dto)
        {
            await ValidateTelefonoRequest(null, dto);
            return await base.CreateAsync(dto);
        }

        public override async Task<TelefonoDTO> UpdateAsync(Guid id, TelefonoRequestDTO dto)
        {
            var existingTelefono = await _repository.GetByIdAsync(id);
            if (existingTelefono == null)
                throw new KeyNotFoundException($"El telefono no existe");
            await ValidateTelefonoRequest(id, dto);
            return await base.UpdateAsync(id, dto);
        }


        //Metodo aux
        private async Task ValidateTelefonoRequest(Guid? id, TelefonoRequestDTO dto)
        {
            //Validar ClienteId
            if(await _repository.EntityExistsAsync(dto.ClienteId))
                throw new KeyNotFoundException($"El clienteId no existe");

            //Validar TipoTelefonoId
            if (await _tipoTelefonoRepository.EntityExistsAsync(dto.TipoTelefonoId))
                throw new KeyNotFoundException($"El tipoTelefonoId no existe");


        }
    }
}
