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

        public async Task<ClienteDetailDTO> GetByIdWithAllDataAsync(Guid id)
        {
            var cliente = await _repository.GetByIdWithAllDataAsync(id);
            if (cliente == null)
                return null;
            var clienteDetailDTO = _mapper.Map<ClienteDetailDTO>(cliente);
            return clienteDetailDTO;
        }

        public override async Task<ClienteDTO> CreateAsync(ClienteRequestDTO dto)
        {
            await ValidateClienteRequest(null, dto);
            return await base.CreateAsync(dto);

        }

        public override async Task<ClienteDTO> UpdateAsync(Guid id, ClienteRequestDTO dto)
        {
            await ValidateClienteRequest(id, dto);
            return await base.UpdateAsync(id, dto);
        }


        private async Task ValidateClienteRequest(Guid? id, ClienteRequestDTO dto)
        {
            // Validar modelo
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if (id.HasValue)
            {
                var clientExiste = await base.GetByIdAsync(id.Value);
                if (clientExiste == null)
                    throw new Exception("El cliente no existe");
            }
            else
            {
                // Validar que no exista un cliente con el mismo email
                var clientes = await _repository.GetAllAsync();
                if (clientes.Any(c => c.Email == dto.Email))
                    throw new Exception("Ya existe un cliente con ese email");
            }

            // Validar que la empresa exista
            if (dto.EmpresaId != null)
            {
                var empresa = await _empresaRepository.GetByIdAsync(dto.EmpresaId.Value);
                if (empresa == null)
                    throw new Exception("La empresa no existe");
            }
        }
    }
}
