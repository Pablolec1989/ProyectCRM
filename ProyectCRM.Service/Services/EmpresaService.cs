using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public override async Task<EmpresaDTO> CreateAsync(EmpresaRequestDTO dto)
        {
            await ValidateEmpresaRequest(null, dto);

            return await base.CreateAsync(dto);
        }

        public override async Task<EmpresaDTO> UpdateAsync(Guid id, EmpresaRequestDTO dto)
        {
            await ValidateEmpresaRequest(id, dto);

            return await base.UpdateAsync(id, dto);
        }

        //Metodos auxiliares
        private async Task ValidateEmpresaRequest(Guid? id, EmpresaRequestDTO dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            await EmpresaExists(dto);
            await RubroExists(dto.RubroId);
            await CondicionIvaExists(dto.CondicionIvaId);
        }
        private async Task EmpresaExists(EmpresaRequestDTO dto)
        {
            var empresaExists = await _repository.GetEmpresaByRazonSocial(dto.RazonSocial);

            if (empresaExists)
                throw new ValidationException($"El rubro no existe.");

        }
        private async Task RubroExists(Guid rubroId)
        {
            var rubroExists = await _rubroRepository.GetByIdAsync(rubroId);
            if (rubroExists == null)
                throw new ValidationException($"El rubro no existe.");
        }
        private async Task CondicionIvaExists(Guid condicionIvaId)
        {
            var condicionIvaExists = await _condicionIvaRepository.GetByIdAsync(condicionIvaId);
            if (condicionIvaExists == null)
                throw new ValidationException($"La condicion IVA no existe.");
        }
    }
}
