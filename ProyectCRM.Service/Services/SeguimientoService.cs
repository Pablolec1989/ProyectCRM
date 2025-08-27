using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class SeguimientoService : ServiceBase<SeguimientoDTO, SeguimientoRequestDTO, Seguimiento>, ISeguimientoService
    {
        public SeguimientoService(IMapper mapper, 
            ISeguimientoRepository repository, 
            IValidator<SeguimientoRequestDTO> validator) 
            : base(mapper, repository, validator)
        {
        }
    }
}
