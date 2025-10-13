using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> 
        where T : EntityBase
    {
        private readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
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
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                    return false;
                
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            
            catch (Exception ex)
            {

                throw new Exception($"Error al eliminar {ex.Message}", ex);
            }
            

        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var entityExists = await _context.Set<T>().FindAsync(id);
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

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var existingEntity = await _context.Set<T>().FindAsync(entity.Id);
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
            var exists = await _context.Set<T>().AnyAsync(e => e.Id == id);
            if(exists)
            {
                return true;
            }
            return false;

        }
    }
}
