using FluentValidation;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Validators.Utils;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Validators
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
        }
    }
}
