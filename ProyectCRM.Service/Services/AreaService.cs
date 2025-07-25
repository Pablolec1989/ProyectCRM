using ProyectCRM.Data;
using ProyectCRM.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class AreaService<AreaDTO, Area> : IServiceBase<AreaDTO>
        where AreaDTO : class
        where Area : class
    {
        private readonly ServiceBase<AreaDTO, Area> _serviceBase;
        private readonly AreaRepository _repository;

        public AreaService(ServiceBase<AreaDTO, Area> serviceBase, 
            AreaRepository repository)
        {
            _serviceBase = serviceBase;
            _repository = repository;
        }

        public async Task<AreaDTO> CreateAsync(AreaDTO area)
        {
            return await _serviceBase.CreateAsync(area);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _serviceBase.DeleteAsync(id);
        }

        public async Task<IEnumerable<AreaDTO>> GetAllAsync()
        {
            return await _serviceBase.GetAllAsync();
        }

        public async Task<AreaDTO> GetByIdAsync(Guid id)
        {
            return await _serviceBase.GetByIdAsync(id);
        }

        public async Task<AreaDTO> UpdateAsync(Guid id, AreaDTO entity)
        {
            return await _serviceBase.UpdateAsync(id, entity);
        }
    }
}
