using FluentValidation;
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
    public class LlamadoService : ServiceBase<LlamadoDTO, LlamadoRequestDTO, Llamado>, ILlamadoService
    {
        public LlamadoService(ILlamadoMapper mapper, ILlamadoRepository repository, IValidator<LlamadoRequestDTO> validator)
            : base(mapper, repository, validator)
        {
        }
    }
}
