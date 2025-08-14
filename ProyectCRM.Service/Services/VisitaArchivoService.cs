using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Service.Utilities;
using ProyectCRM.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class VisitaArchivoService : ServiceBase<VisitaArchivoDTO, VisitaArchivoUpdateCreateDTO, VisitaArchivo>, IVisitaArchivoService
    {
        private readonly IVisitaArchivoMapper _mapper;
        private readonly IVisitaArchivoRepository _repository;
        private readonly IValidator<VisitaArchivo> _validator;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly IEmpresaRepository _empresaRepository;

        public VisitaArchivoService(IVisitaArchivoMapper mapper,
            IVisitaArchivoRepository repository,
            IValidator<VisitaArchivo> validator,
            IAlmacenadorArchivos almacenadorArchivos,
            IEmpresaRepository empresaRepository) : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
            _almacenadorArchivos = almacenadorArchivos;
            _empresaRepository = empresaRepository;
        }

        public IEmpresaRepository EmpresaRepository { get; }

        public override async Task<VisitaArchivoDTO> CreateAsync(VisitaArchivoUpdateCreateDTO dto)
        {
            // 1. Obtener la empresa por EmpresaId
            var empresa = await _empresaRepository.GetByIdAsync(dto.EmpresaId);
            if (empresa == null)
                throw new Exception("Empresa no encontrada.");

            // 2. Usar el nombre de la empresa como contenedor
            var contenedor = empresa.RazonSocial.ToLower().Replace(" ", "-");

            // 3. Almacenar el archivo y obtener la ruta
            var rutaArchivo = await _almacenadorArchivos.Almacenar(contenedor, dto.RutaArchivo);

            // 4. Mapear el DTO a entidad y asignar la ruta
            var entityToCreate = _mapper.ToEntity(dto);
            entityToCreate.RutaArchivo = rutaArchivo;
            entityToCreate.EmpresaId = empresa.Id;
            entityToCreate.Empresa = empresa;

            // 5. Validar la entidad
            var validationResult = _validator.Validate(entityToCreate);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // 6. Guardar la entidad en la base de datos
            var createdEntity = await _repository.CreateAsync(entityToCreate);

            // 7. Retornar el DTO
            return _mapper.ToDTO(createdEntity);
        }

        public override async Task<VisitaArchivoDTO> UpdateAsync(Guid id, VisitaArchivoUpdateCreateDTO dto)
        {
            // 1. Obtener la entidad existente
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
                throw new Exception("VisitaArchivo no encontrado.");

            // 2. Obtener la empresa por EmpresaId
            var empresa = await _empresaRepository.GetByIdAsync(dto.EmpresaId);
            if (empresa == null)
                throw new Exception("Empresa no encontrada.");

            // 3. Usar el nombre de la empresa como contenedor
            var contenedor = empresa.RazonSocial.ToLower().Replace(" ", "-");

            // 4. Almacenar el archivo y obtener la ruta
            var rutaArchivo = await _almacenadorArchivos.Almacenar(contenedor, dto.RutaArchivo);

            // 5. Mapear el DTO a entidad y asignar la ruta
            var entityToUpdate = _mapper.ToEntity(dto);
            entityToUpdate.Id = id; // Asegurarse de que el ID sea correcto
            entityToUpdate.RutaArchivo = rutaArchivo;
            entityToUpdate.EmpresaId = empresa.Id;
            entityToUpdate.Empresa = empresa;

            // 6. Validar la entidad
            var validationResult = _validator.Validate(entityToUpdate);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // 7. Actualizar la entidad en la base de datos
            var updatedEntity = await _repository.UpdateAsync(entityToUpdate);

            // 8. Retornar el DTO actualizado
            return _mapper.ToDTO(updatedEntity);


        }
        public override async Task<bool> DeleteAsync(Guid id)
        {
            // 1. Obtener la entidad existente
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
                throw new Exception("VisitaArchivo no encontrado.");
            // 2. Borrar el archivo asociado
            await _almacenadorArchivos.Borrar(existingEntity.RutaArchivo, existingEntity.Empresa.RazonSocial.ToLower().Replace(" ", "-"));
            // 3. Eliminar la entidad de la base de datos
            return await _repository.DeleteAsync(id);
        }
    }
}
