using FluentValidation;
using ProyectCRM.Data;
using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public abstract class ServiceBase<TDTO, TRequestDTO, TEntity> : IServiceBase<TDTO, TRequestDTO, TEntity>
        where TDTO : class
        where TRequestDTO : class, new()
        where TEntity : EntityBase
    {
        private readonly IMapperBase<TDTO, TRequestDTO, TEntity> _mapper;
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IValidator<TRequestDTO> _validator;

        public ServiceBase(IMapperBase<TDTO, TRequestDTO, TEntity> mapper, 
            IRepositoryBase<TEntity> repository, 
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
            var entityToCreate = _mapper.FromRequestDtoToEntity(dto);
            var createdEntity = await _repository.CreateAsync(entityToCreate);
            return _mapper.FromEntityToDto(createdEntity);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.ToListDTO(entities);
        }

        public virtual async Task<TDTO> GetByIdAsync(Guid id)
        {
            return _mapper.FromEntityToDto(await _repository.GetByIdAsync(id));
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
            var entityToUpdate = _mapper.FromRequestDtoToEntity(dto);
            //Le asigno el Id!
            entityToUpdate.Id = id;
            var updatedEntity = await _repository.UpdateAsync(entityToUpdate);
            return _mapper.FromEntityToDto(updatedEntity);
        }
    }
}