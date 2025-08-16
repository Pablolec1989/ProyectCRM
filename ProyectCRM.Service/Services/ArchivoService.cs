using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class ArchivoService : ServiceBase<ArchivoDTO, ArchivoUpdateCreateDTO, Archivo>, IArchivoService
    {
        public ArchivoService(IArchivoMapper mapper, IArchivoRepository repository, IValidator<Archivo> validator) : base(mapper, repository, validator)
        {
        }
    }
        
}
