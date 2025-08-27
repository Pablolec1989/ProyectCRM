using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Services
{
    public class ArchivoService : IArchivoService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _contextAccessor;

        public ArchivoService(IWebHostEnvironment environment, IHttpContextAccessor contextAccessor)
        {
            _environment = environment;
            _contextAccessor = contextAccessor;
        }

        public async Task<string> CreateAsync(string contenedor, IFormFile archivo)
        {
            var extension = Path.GetExtension(archivo.FileName);
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_environment.WebRootPath, contenedor);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string ruta = Path.Combine(folder, nombreArchivo);

            using (var ms = new MemoryStream())
            {
                await archivo.CopyToAsync(ms);
                var contenido = ms.ToArray();
                await File.WriteAllBytesAsync(ruta, contenido);
            }
            var request = _contextAccessor.HttpContext!.Request;
            var url = $"{request.Scheme}://{request.Host}/{contenedor}/{nombreArchivo}";
            var urlArchivo = Path.Combine(url, contenedor, nombreArchivo).Replace("\\", "/");

            return urlArchivo;
        }

        public async Task<string> UpdateAsync(string contenedor, IFormFile archivo, string? ruta)
        {
            await DeleteAsync(ruta, contenedor);
            return await CreateAsync(contenedor, archivo);
        }

        public Task DeleteAsync(string? ruta, string contenedor)
        {
            if (string.IsNullOrEmpty(ruta))
            {
                throw new Exception("No se ha proporcionado una ruta válida.");
            }
            var nombreArchivo = Path.GetFileName(ruta);
            var directorioArchivo = Path.Combine(_environment.WebRootPath, contenedor, nombreArchivo);

            if (File.Exists(directorioArchivo))
            {
                File.Delete(directorioArchivo);
            }

            return Task.CompletedTask;
        }
    }
        
}
