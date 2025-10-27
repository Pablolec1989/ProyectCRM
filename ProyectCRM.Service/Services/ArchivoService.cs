using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.Service.Validators;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class ArchivoService : ServiceBase<ArchivoDTO, ArchivoRequestDTO, Archivo>, IArchivoService
    {
        private readonly IArchivoRepository _repository;
        private readonly IValidator<ArchivoRequestDTO> _validator;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private const string contenedor = "archivos";

        public ArchivoService(IMapper mapper,
            IArchivoRepository repository,
            IVisitaRepository visitaRepository,
            IValidator<ArchivoRequestDTO> validator,
            IFileStorageService fileStorageService)
            : base(mapper, repository, validator)
        {
            _repository = repository;
            _validator = validator;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        public async Task<ArchivoDTO> CreateAsync(ArchivoRequestDTO dto, IFormFile archivo)
        {
            var rutaArchivo = await _fileStorageService.CreateFileAsync(contenedor, archivo);
            await ValidationArchivoRequest(null, dto);

            var entityToCreate = _mapper.Map<Archivo>(dto);
            entityToCreate.RutaArchivo = rutaArchivo;
            var createdEntity = await _repository.CreateAsync(entityToCreate);
            return _mapper.Map<ArchivoDTO>(createdEntity);
        }

        public async Task<ArchivoDTO> UpdateAsync(Guid id, ArchivoRequestDTO dto, IFormFile archivo)
        {
            var archivoExistente = await _repository.GetByIdAsync(id);
            if (archivoExistente == null)
                throw new Exception("El archivo no existe");

            var nuevaRutaArchivo = await _fileStorageService.UpdateFileAsync(contenedor, archivo, archivoExistente.RutaArchivo);

            await ValidationArchivoRequest(id, dto);

            archivoExistente.NombreArchivo = dto.NombreArchivo;
            archivoExistente.VisitaId = dto.VisitaId;
            archivoExistente.RutaArchivo = nuevaRutaArchivo;

            await _repository.UpdateAsync(archivoExistente);
            return _mapper.Map<ArchivoDTO>(archivoExistente);
        }

        //Metodo aux
        private async Task ValidationArchivoRequest(Guid? id, ArchivoRequestDTO dto)
        {
            //Validar modelo
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //Validar que la visita exista
            if (await _repository.EntityExistsAsync(dto.VisitaId))
                throw new InvalidOperationException("La visita no existe.");

        }
    }
}
