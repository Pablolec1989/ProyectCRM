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
    public class VisitaValidator : AbstractValidator<VisitaRequestDTO>
    {
        public VisitaValidator()
        {
            RuleFor(v => v.Observaciones)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(500).WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(v => v.ClienteId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(v => v.DireccionId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(v => v.UsuariosIds)
                .NotNull().WithMessage(ValidationMessages.CampoObligatorio)
                .Must(list => list != null && list.Count > 0).WithMessage("Debe asignar al menos un usuario a la visita.");

        }
    }
}
