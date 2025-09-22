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
    public class TelefonoValidator : AbstractValidator<TelefonoRequestDTO>
    {
        public TelefonoValidator()
        {
            RuleFor(tc => tc.Numero)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));

            RuleFor(tc => tc.ClienteId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(tc => tc.TipoTelefonoId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);
        }
    }
}
