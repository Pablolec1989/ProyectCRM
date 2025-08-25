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
    public class LlamadoValidator : AbstractValidator<LlamadoRequestDTO>
    {
        public LlamadoValidator()
        {
            RuleFor(l => l.Detalle)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(300).WithMessage(ValidationMessages.MaxLength(300));

            RuleFor(l => l.ClienteId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(l => l.UsuarioId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(l => l.AsuntoDeContactoId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

        }
    }
}
