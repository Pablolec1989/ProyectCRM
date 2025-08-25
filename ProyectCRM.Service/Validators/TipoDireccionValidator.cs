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
    public class TipoDireccionValidator : AbstractValidator<TipoDireccionRequestDTO>
    {
        public TipoDireccionValidator()
        {
            RuleFor(td => td.Nombre)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLength(100));
        }
    }
}
