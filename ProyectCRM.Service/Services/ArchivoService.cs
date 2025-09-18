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
        private readonly IArchivoRepository _archivoRepository;
        private readonly IVisitaRepository _visitaRepository;
        private readonly IValidator<ArchivoRequestDTO> _validator;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private const string contenedor = "archivos";

        public ArchivoService(IMapper mapper,
            IArchivoRepository archivoRepository,
            IVisitaRepository visitaRepository,
            IValidator<ArchivoRequestDTO> validator,
            IFileStorageService fileStorageService)
            : base(mapper, archivoRepository, validator)
        {
            _archivoRepository = archivoRepository;
            _visitaRepository = visitaRepository;
            _validator = validator;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        public override async Task<ArchivoDTO> CreateAsync(ArchivoRequestDTO archivoRequestDTO)
        {

            var validationResult = _validator.Validate(archivoRequestDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var visitaExiste = await _visitaRepository.GetByIdAsync(archivoRequestDTO.VisitaId);
            if (visitaExiste == null)
            {
                throw new KeyNotFoundException($"Visita no encontrada");
            }

            var archivo = _mapper.Map<Archivo>(archivoRequestDTO);

            // Guardar el archivo en el almacenamiento y obtener la ruta
            var nuevaRutaArchivo = await _fileStorageService.CreateFileAsync(contenedor, archivoRequestDTO.RutaArchivo);
            archivo.RutaArchivo = nuevaRutaArchivo;
            archivo.FechaSubida = DateOnly.FromDateTime(DateTime.Now);

            var archivoCreado = await _archivoRepository.CreateAsync(archivo);
            var resultado = _mapper.Map<ArchivoDTO>(archivoCreado);
            return resultado;

        }

        public override async Task<ArchivoDTO> UpdateAsync(Guid archivoId, ArchivoRequestDTO archivoRequestDTO)
        {
            var validationResult = _validator.Validate(archivoRequestDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var archivo = await _archivoRepository.GetByIdAsync(archivoId);
            if (archivo == null)
            {
                throw new KeyNotFoundException($"Archivo no encontrado");
            }

            var visitaExiste = await _visitaRepository.GetByIdAsync(archivoRequestDTO.VisitaId);
            if(visitaExiste == null)
            {
                throw new KeyNotFoundException($"Visita no encontrada");
            }

            var nuevaRuta = await _fileStorageService.UpdateFileAsync(contenedor, archivoRequestDTO.RutaArchivo, archivo.RutaArchivo);
            archivo.NombreArchivo = archivoRequestDTO.NombreArchivo;
            archivo.RutaArchivo = nuevaRuta;
            archivo.VisitaId = archivoRequestDTO.VisitaId;

            var archivoActualizado = await _archivoRepository.UpdateAsync(archivo);
            var resultado = _mapper.Map<ArchivoDTO>(archivoActualizado);
            return resultado;


        }
        
        public override async Task<bool> DeleteAsync(Guid archivoId)
        {
            var archivo = await _archivoRepository.GetByIdAsync(archivoId);
            if (archivo == null)
            {
                throw new KeyNotFoundException($"Archivo no encontrado");
            }
            await _fileStorageService.DeleteFileAsync(archivo.RutaArchivo, contenedor);
            return await _archivoRepository.DeleteAsync(archivoId);

        }
    }
        
}
