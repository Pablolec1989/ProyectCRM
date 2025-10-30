using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class EmpresaService : ServiceBase<EmpresaDTO, EmpresaRequestDTO, Empresa>, IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _repository;
        public readonly IRubroRepository _rubroRepository;
        public readonly ICondicionIvaRepository _condicionIvaRepository;
        private readonly IValidator<EmpresaRequestDTO> _validator;

        public EmpresaService(IMapper mapper,
            IEmpresaRepository repository,
            IRubroRepository rubroRepository,
            ICondicionIvaRepository condicionIvaRepository,
            IValidator<EmpresaRequestDTO> validator) : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _rubroRepository = rubroRepository;
            _condicionIvaRepository = condicionIvaRepository;
            _validator = validator;
        }

        public async Task<EmpresaDetailDTO> GetEmpresaDetailDTOAsync(Guid id)
        {
            var empresa = await _repository.GetEmpresaDetailDTOAsync(id);
            if (empresa == null)
                throw new KeyNotFoundException($"La empresa no fue encontrada.");
            return _mapper.Map<EmpresaDetailDTO>(empresa);
        }

        public override async Task<EmpresaDTO> CreateAsync(EmpresaRequestDTO dto)
        {
            var empresaExists = await _repository.GetEmpresaByRazonSocialAsync(dto.RazonSocial);
            if (empresaExists)
                throw new ValidationException($"El rubro no existe.");

            await ValidateEmpresaRequest(null, dto);
            return await base.CreateAsync(dto);
        }

        public override async Task<EmpresaDTO> UpdateAsync(Guid id, EmpresaRequestDTO dto)
        {
            await ValidateEmpresaRequest(id, dto);
            return await base.UpdateAsync(id, dto);
        }
        public async Task<IEnumerable<EmpresaDTO>> SearchPaginatedAsync(PaginationDTO pagination)
        {
            var entities = await _repository.SearchPaginatedAsync(pagination);
            return _mapper.Map<IEnumerable<EmpresaDTO>>(entities);

        }

        //Metodos auxiliares
        private async Task ValidateEmpresaRequest (Guid? id, EmpresaRequestDTO dto)
        {
            if (await _repository.EntityExistsAsync(dto.RubroId))
                    throw new ValidationException($"El rubroId no existe.");
            
            if (await _repository.EntityExistsAsync(dto.CondicionIvaId))
                    throw new ValidationException($"La condicionIvaId no existe.");
        }

    }
}
