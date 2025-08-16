using FluentValidation;
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
    public class SeguimientoService : ServiceBase<SeguimientoDTO, SeguimientoUpdateCreateDTO, Seguimiento>, ISeguimientoService
    {
        public SeguimientoService(ISeguimientoMapper mapper, ISeguimientoRepository repository, IValidator<Seguimiento> validator) : base(mapper, repository, validator)
        {
        }
    }
}
