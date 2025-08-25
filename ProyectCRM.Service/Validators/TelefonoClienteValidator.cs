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
    public class TelefonoClienteValidator : AbstractValidator<TelefonoClienteRequestDTO>
    {
        public TelefonoClienteValidator()
        {
            RuleFor(t => t.Numero)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(20).WithMessage(ValidationMessages.MaxLength(20));

            RuleFor(t => t.ClienteId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(t => t.TipoTelefonoId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);
        }
    }
}
