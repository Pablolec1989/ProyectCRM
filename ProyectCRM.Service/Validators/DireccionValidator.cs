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
    public class DireccionValidator : AbstractValidator<DireccionRequestDTO>
    {
        public DireccionValidator()
        {
            RuleFor(d => d.Calle)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLength(100));

            RuleFor(d => d.Numero)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)

            RuleFor(d => d.Ciudad)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(100));

            RuleFor(d => d.CodigoPostal)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(20).WithMessage(ValidationMessages.MaxLength(100));

            RuleFor(d => d.Provincia)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(100));

            RuleFor(d => d.TipoDireccionId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);
        }
    }
}
