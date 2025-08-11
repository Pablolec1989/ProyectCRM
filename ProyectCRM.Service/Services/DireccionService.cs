using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.DireccionDTO;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class DireccionService : ServiceBase<DireccionDTO, DireccionCreateDTO, Direccion>, IDireccionService
    {
        private readonly IDireccionMapper _mapper;
        private readonly IDireccionRepository _repository;

        public DireccionService(IDireccionMapper mapper, IDireccionRepository repository) : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DireccionDTO> GetByIdWithTipoDireccionAsync(Guid id)
        {
            var direccion = await _repository.GetByIdWithTipoDireccionAsync(id);
            return _mapper.ToDTO(direccion);
        }
    }
}
