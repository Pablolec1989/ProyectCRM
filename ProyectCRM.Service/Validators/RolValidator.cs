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
    public class RolValidator : AbstractValidator<RolRequestDTO>
    {
        public RolValidator()
        {
            RuleFor(r => r.Nombre)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));
        }
    }
}
