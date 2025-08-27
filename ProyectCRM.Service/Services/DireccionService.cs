using FluentValidation;
using MapsterMapper;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class DireccionService : ServiceBase<DireccionDTO, DireccionRequestDTO, Direccion>, IDireccionService
    {
        private readonly IDireccionMapper _mapper;
        private readonly IDireccionRepository _repository;

        public DireccionService(IMapper mapper, 
            IDireccionRepository repository, 
            IValidator<DireccionRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
        }
    }
}
