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
    public class CondicionIvaValidator : AbstractValidator<CondicionIvaRequestDTO>
    {
        public CondicionIvaValidator()
        {
            RuleFor(a => a.Nombre)
            .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
            .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));
        }
    }
}
