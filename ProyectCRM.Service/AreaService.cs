using ProyectCRM.Data;
using ProyectCRM.Mapper;
using ProyectCRM.Mapper.AreaDTOs;
using ProyectCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public class AreaService : IService<AreaCreateUpdateDTO, AreaDTO>
    {
        private readonly IRepository<Area> _repository;
        private readonly IMapper<AreaDTO, AreaCreateUpdateDTO, Area> _mapper;

        public AreaService(IRepository<Area> repository,
            IMapper<AreaDTO, AreaCreateUpdateDTO, Area>
            mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AreaDTO> CreateAsync(AreaCreateUpdateDTO createDto)
        {
            var area = _mapper.ToEntity(createDto);

            //Validar que no exista un area con el mismo nombre 
            var existeArea = await _repository.GetAllAsync();
            if (existeArea.Any(a => a.nombre.Equals(area.nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Ya existe un área con el mismo nombre");
            }
            //Valido que el nombre no sea nulo o vacio
            if (createDto.nombre == null || createDto.nombre.Trim() == "")
            {
                throw new Exception("El nombre del área no puede estar vacío");
            }

            await _repository.CreateAsync(area);
            return _mapper.ToDTO(area);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var areaExiste = await _repository.GetByIdAsync(id);
            if (areaExiste == null)
            {
                throw new Exception("Esta entidad no existe");
            }
            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<AreaDTO>> GetAllAsync()
        {
            var areas = await _repository.GetAllAsync();
            return _mapper.ToDTOList(areas);
        }

        public async Task<AreaDTO> GetByIdAsync(int id)
        {
            var area = await _repository.GetByIdAsync(id);
            if(area == null)
            {
                throw new Exception("Esta entidad no existe");
            }
            return _mapper.ToDTO(area);

        }

        public async Task<AreaDTO> UpdateAsync(int id, AreaCreateUpdateDTO updateDto)
        {
            var area = await _repository.GetByIdAsync(id);
            if (area == null)
            {
                throw new Exception("Esta entidad no existe");
            }
            //Validar que no exista un area con el mismo nombre 
            var existeArea = await _repository.GetAllAsync();
            if (existeArea.Any(a => a.nombre.Equals(updateDto.nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Ya existe un área con el mismo nombre");
            }
            //Valido que el nombre no sea nulo o vacio
            if (updateDto.nombre == null || updateDto.nombre.Trim() == "")
            {
                throw new Exception("El nombre del área no puede estar vacío");
            }
            area = _mapper.ToEntity(updateDto);
            await _repository.UpdateAsync(id, area);
            return _mapper.ToDTO(area);
        }

    }
}
