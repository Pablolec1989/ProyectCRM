using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class EmpresaValidator : AbstractValidator<EmpresaRequestDTO>
    {
        public EmpresaValidator()
        {
            RuleFor(e => e.RazonSocial).MaximumLength(200);
            RuleFor(e => e.CUIT).MaximumLength(200);
            RuleFor(e => e.CUIT).MaximumLength(200);
        }
    }
}
