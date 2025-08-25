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
    public class UsuarioValidator : AbstractValidator<UsuarioRequestDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MinimumLength(8).WithMessage(ValidationMessages.MinLength(8))
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLength(100));

            RuleFor(x => x.RolId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

        }
    }
}
