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
    public class VisitaUsuarioValidator : AbstractValidator<VisitaUsuarioRequestDTO>
    {
        public VisitaUsuarioValidator()
        {
            RuleFor(v => v.UsuarioId)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(v => v.UsuarioId)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.CampoObligatorio);
        }
    }
}
