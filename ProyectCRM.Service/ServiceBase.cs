using ProyectCRM.Data;
using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public abstract class ServiceBase<TDTO, TCreateDTO, TEntity> : IServiceBase<TDTO, TCreateDTO, TEntity>
        where TDTO : class
        where TCreateDTO : class, new()
        where TEntity : EntityBase
    {
        private readonly IMapperBase<TDTO, TCreateDTO, TEntity> _mapper;
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IMapperBase<TDTO, TCreateDTO, TEntity> mapper, IRepositoryBase<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<TDTO> CreateAsync(TCreateDTO dto)
        {
            var entityToCreate = _mapper.ToEntity(dto);
            var createdEntity = await _repository.CreateAsync(entityToCreate);
            return _mapper.ToDTO(createdEntity);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            return _mapper.ToListDTO(await _repository.GetAllAsync());
        }

        public virtual async Task<TDTO> GetByIdAsync(Guid id)
        {
            return _mapper.ToDTO(await _repository.GetByIdAsync(id));
        }

        public virtual async Task<TDTO> UpdateAsync(Guid id, TDTO dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return null;
            }
            var entityToUpdate = _mapper.ToEntity(dto);
            //Le asigno el Id!
            entityToUpdate.Id = id;
            var updatedEntity = await _repository.UpdateAsync(entityToUpdate);
            return _mapper.ToDTO(updatedEntity);
        }
    }
}