using Microsoft.EntityFrameworkCore;
using ProyectCRM.Data.Utils;
using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data
{
    public abstract class RepositoryBase<FilterPaginatedDTO, TEntity> : IRepositoryBase<FilterPaginatedDTO, TEntity> 
        where TEntity : EntityBase
        where FilterPaginatedDTO : class
    {
        private readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la creacion {ex.Message}", ex);
            }
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                    return false;
                
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            
            catch (Exception ex)
            {

                throw new Exception($"Error al eliminar {ex.Message}", ex);
            }
            

        }

        public virtual async Task<IEnumerable<TEntity>> SearchPaginatedAsync(FilterPaginatedDTO filterPaginatedDTO)
        {
            return await Query()
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                var entityExists = await _context.Set<TEntity>().FindAsync(id);
                if (entityExists == null)
                {
                    return null;
                }
                return entityExists;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la creacion {ex.Message}", ex);
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                var existingEntity = await _context.Set<TEntity>().FindAsync(entity.Id);
                if (existingEntity == null)
                {
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return existingEntity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar {ex.Message}", ex);
            }


        }

        public virtual async Task<bool> EntityExistsAsync(Guid id)
        {
            var exists = await _context.Set<TEntity>().AnyAsync(e => e.Id == id);
            if(exists)
            {
                return true;
            }
            return false;

        }
    }
}
