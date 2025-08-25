using FluentValidation;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Validators.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class VisitaValidator : AbstractValidator<VisitaRequestDTO>
    {
        public VisitaValidator()
        {
            RuleFor(v => v.Observaciones)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(500).WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(v => v.ClienteId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(v => v.DireccionId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

        }
    }
}
