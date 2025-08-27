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
    public class MailValidator : AbstractValidator<MailRequestDTO>
    {
        public MailValidator()
        {
            RuleFor(m => m.Detalle)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(300).WithMessage(ValidationMessages.MaxLength(300));

            RuleFor(m => m.ClienteId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(m => m.UsuarioId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(m => m.AsuntoDeContactoId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);


        }
    }
}
