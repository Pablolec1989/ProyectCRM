using FluentValidation;
using MapsterMapper;
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
    public class EmpresaService : ServiceBase<EmpresaDTO, EmpresaRequestDTO, Empresa>, IEmpresaService
    {
        public EmpresaService(IMapper mapper, 
            IEmpresaRepository repository, 
            IValidator<EmpresaRequestDTO> validator) : base(mapper, repository, validator)
        {
        }

    }
}
