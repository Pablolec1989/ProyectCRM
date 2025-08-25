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
    public class SeguimientoValidator : AbstractValidator<SeguimientoRequestDTO>
    {
        public SeguimientoValidator()
        {
            RuleFor(s => s.Titulo)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(20).WithMessage(ValidationMessages.MaxLength(20));

            RuleFor(s => s.Detalle)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(300).WithMessage(ValidationMessages.MaxLength(300));

            RuleFor(s => s.ClienteId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(s => s.UsuarioId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);
        }
    }
}
