using FluentValidation;
using Mapster;
using MapsterMapper;
using ProyectCRM.Models.Data;
using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service
{
    public abstract class ServiceBase<TDTO, TRequestDTO, FilterPaginatedDTO, TEntity> : IServiceBase<TDTO, TRequestDTO, FilterPaginatedDTO, TEntity>
        where TDTO : class
        where TRequestDTO : class, new()
        where FilterPaginatedDTO: class
        where TEntity : EntityBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<FilterPaginatedDTO, TEntity> _repository;
        private readonly IValidator<TRequestDTO> _validator;

        public ServiceBase(IMapper mapper, 
            IRepositoryBase<FilterPaginatedDTO, TEntity> repository, 
            IValidator<TRequestDTO> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public virtual async Task<TDTO> CreateAsync(TRequestDTO dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var entityToCreate = _mapper.Map<TEntity>(dto);
            var createdEntity = await _repository.CreateAsync(entityToCreate);
            return _mapper.Map<TDTO>(createdEntity);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<TDTO> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDTO>(entity);
        }

        public async Task<IEnumerable<TDTO>> SearchPaginatedAsync(FilterPaginatedDTO filterPaginatedDTO)
        {
            var entities = await _repository.SearchPaginatedAsync(filterPaginatedDTO);
            return _mapper.Map<IEnumerable<TDTO>>(entities);
        }

        public virtual async Task<TDTO> UpdateAsync(Guid id, TRequestDTO dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return null;
            }

            var validationResult = _validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var entityToUpdate = _mapper.Map<TEntity>(dto);
            //Le asigno el Id
            entityToUpdate.Id = id;
            var updatedEntity = await _repository.UpdateAsync(entityToUpdate);
            return _mapper.Map<TDTO>(updatedEntity);
        }
    }
}