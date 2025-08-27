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
