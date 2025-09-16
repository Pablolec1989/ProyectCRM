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
    public class UsuarioValidator : AbstractValidator<UsuarioRegisterDTO>
    {
        public UsuarioValidator()
        {

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MinimumLength(8).WithMessage(ValidationMessages.MinLength(8))
                .MaximumLength(250).WithMessage(ValidationMessages.MaxLength(250));

            RuleFor(x => x.RolId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

        }
    }
}
