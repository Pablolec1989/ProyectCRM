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
    public class VisitaService : ServiceBase<VisitaDTO, VisitaRequestDTO, Visita>, IVisitaService
    {
        public VisitaService(IVisitaMapper mapper, 
            IVisitaRepository repository, 
            IValidator<VisitaRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
        }
    }
}
