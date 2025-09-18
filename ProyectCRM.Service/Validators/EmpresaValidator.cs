using FluentValidation;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Validators.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Validators
{
    public class EmpresaValidator : AbstractValidator<EmpresaRequestDTO>
    {
        public EmpresaValidator()
        {
            RuleFor(e => e.RazonSocial)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(200).WithMessage(ValidationMessages.MaxLength(200));
            
            RuleFor(e => e.Cuit)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MinimumLength(13).WithMessage(ValidationMessages.MinLength(13));

            RuleFor(e => e.Cuit)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MinimumLength(13).WithMessage(ValidationMessages.MinLength(13));


        }
    }
}
