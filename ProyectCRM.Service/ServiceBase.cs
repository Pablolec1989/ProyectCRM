using ProyectCRM.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public class ServiceBase<TDTO, TEntity> : IServiceBase<TDTO, TEntity>
        where TDTO : class
        where TEntity : class
    {
        private readonly IMapperBase<TDTO, TEntity> _mapper;
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IMapperBase<TDTO, TEntity> mapper, IRepositoryBase<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<TDTO> CreateAsync(TDTO entity)
        {
            var entityToCreate = await _mapper.ToEntityAsync(entity);
            var createdEntity = await _repository.CreateAsync(entityToCreate);
            return await _mapper.ToDTOAsync(createdEntity);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted;
        }

        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return await _mapper.ToDTOListAsync(entities);
        }

        public virtual async Task<TDTO> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return await _mapper.ToDTOAsync(entity);
        }

        public virtual async Task<TDTO> UpdateAsync(Guid id, TDTO entity)
        {
            var entityToUpdate = await _mapper.ToEntityAsync(entity);
            var updatedEntity = await _repository.UpdateAsync(id, entityToUpdate);
            return await _mapper.ToDTOAsync(updatedEntity);
        }
    }
}
