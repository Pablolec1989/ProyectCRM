using ProyectCRM.Data;
using ProyectCRM.Models.Abstractions;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public abstract class ServiceBase<TDTO, TEntity> : IServiceBase<TDTO, TEntity>
        where TDTO : class
        where TEntity : EntityBase
    {
        private readonly IMapperBase<TDTO, TEntity> _mapper;
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IMapperBase<TDTO, TEntity> mapper, IRepositoryBase<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<TDTO> CreateAsync(TDTO dto)
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
            return _mapper.ToListDTO((await _repository.GetAllAsync()));
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
            entityToUpdate.id = id;
            var updatedEntity = await _repository.UpdateAsync(entityToUpdate);
            return _mapper.ToDTO(updatedEntity);
        }

    }
}