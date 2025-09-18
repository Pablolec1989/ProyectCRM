using FluentValidation;
using MapsterMapper;
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
    public class ClienteService : ServiceBase<ClienteDTO, ClienteRequestDTO, Cliente>, IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IValidator<ClienteRequestDTO> _validator;

        public ClienteService(IMapper mapper, 
            IClienteRepository repository, 
            IEmpresaRepository empresaRepository,
            IValidator<ClienteRequestDTO> validator) : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _empresaRepository = empresaRepository;
            _validator = validator;
        }

        public override async Task<ClienteDTO> CreateAsync(ClienteRequestDTO dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var clientExiste = await base.GetByIdAsync(dto.Id);
            if(clientExiste != null)
            {
                throw new Exception("El cliente ya existe");
            }

            var empresaExiste = await _empresaRepository.GetByIdAsync(dto.EmpresaId);
            if (empresaExiste == null)
            {
                throw new Exception("La empresa no existe");
            }
            
            var cliente = _mapper.Map<Cliente>(dto);
            var createdCliente = await _repository.CreateAsync(cliente);
            var clienteDto = _mapper.Map<ClienteDTO>(createdCliente);
            return clienteDto;

        }

        public override async Task<ClienteDTO> UpdateAsync(Guid id, ClienteRequestDTO dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var clienteExiste = await _repository.GetByIdAsync(id);
            if (clienteExiste == null)
            {
                throw new Exception("El cliente no existe");
            }
            var empresaExiste = await _empresaRepository.GetByIdAsync(dto.EmpresaId);
            if (empresaExiste == null)
            {
                throw new Exception("La empresa no existe");
            }
            var cliente = _mapper.Map<Cliente>(dto);

            var updatedCliente = await _repository.UpdateAsync(cliente);
            var clienteDto = _mapper.Map<ClienteDTO>(updatedCliente);
            return clienteDto;
        }

    }
}
