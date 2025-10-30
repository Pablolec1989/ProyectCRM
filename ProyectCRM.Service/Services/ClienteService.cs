using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
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
        private readonly IValidator<ClienteRequestDTO> _validator;

        public ClienteService(IMapper mapper,
            IClienteRepository repository,
            IEmpresaRepository empresaRepository,
            IValidator<ClienteRequestDTO> validator) : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<ClienteDetailDTO> GetClienteDetailAsync(Guid id)
        {
            var cliente = await _repository.GetClienteDetailAsync(id);
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

        public async Task<IEnumerable<ClienteDTO>> SearchClientesAsync(ClienteFilterPaginatedDTO filter)
        {
            var clientes = await _repository.SearchClienteAsync(filter);
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        //Metod aux
        private async Task ValidateClienteRequest(Guid? id, ClienteRequestDTO dto)
        {
            if(id != null)
            {
                //Validar existencia de cliente por nombre y apellido
                var clienteExistente = await _repository.GetClienteByNombreApellidoAsync(id.Value);
                if (clienteExistente != null)
                {
                    if (clienteExistente.Nombre.Equals(dto.Nombre) &&
                        clienteExistente.Apellido.Equals(dto.Apellido))
                    {
                        throw new Exception("Ya existe un cliente con el mismo nombre y apellido");
                    }
                }
            }
            if(dto.EmpresaId != null)
            {
                // Validar que la empresa exista
                if(await _repository.EntityExistsAsync(dto.EmpresaId.Value))
                    throw new Exception("EmpresaId no existe");
            }

        }

    }
}
