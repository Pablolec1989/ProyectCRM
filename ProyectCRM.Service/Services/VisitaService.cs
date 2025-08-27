using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
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
    public class VisitaService : ServiceBase<VisitaDTO, VisitaRequestDTO, Visita>, IVisitaService
    {
        public VisitaService(IMapper mapper, 
            IVisitaRepository repository, 
            IValidator<VisitaRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
        }
    }
}
