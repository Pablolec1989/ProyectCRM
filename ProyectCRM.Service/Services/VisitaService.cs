using FluentValidation;
using Microsoft.AspNetCore.Http;
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
    public class VisitaService : ServiceBase<VisitaDTO, VisitaUpdateCreateDTO, Visita>, IVisitaService
    {
        private readonly IVisitaMapper mapper;
        private readonly IVisitaRepository repository;
        private readonly IValidator<Visita> validator;

        public VisitaService(IVisitaMapper mapper, IVisitaRepository repository, IValidator<Visita> validator) : base(mapper, repository, validator)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.validator = validator;
        }

        public Task<string> Almacenar(string contenedor, IFormFile archivo)
        {
            throw new NotImplementedException();
        }

        public Task Borrar(string? ruta, string contenedor)
        {
            throw new NotImplementedException();
        }

        public Task<VisitaDTO> CreateAsync(VisitaArchivoUpdateCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<VisitaDTO> UpdateAsync(Guid id, VisitaArchivoUpdateCreateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
