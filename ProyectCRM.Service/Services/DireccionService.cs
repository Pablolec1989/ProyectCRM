using FluentValidation;
using MapsterMapper;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class DireccionService : ServiceBase<DireccionDTO, DireccionRequestDTO, Direccion>, IDireccionService
    {
        private readonly IDireccionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<DireccionRequestDTO> _validator;

        public DireccionService(IMapper mapper, 
            IDireccionRepository repository, 
            IValidator<DireccionRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<DireccionDTO>> GetDireccionesByClienteIdAsync(Guid clienteId)
        {
            var direcciones = await _repository.GetDireccionesByClienteIdAsync(clienteId);
            return _mapper.Map<IEnumerable<DireccionDTO>>(direcciones);

        }
    }
}
