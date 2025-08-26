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
    public class ArchivoValidator : AbstractValidator<ArchivoRequestDTO>
    {
        public ArchivoValidator()
        {
            RuleFor(a => a.NombreArchivo)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(a => a.RutaArchivo)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(a => a.VisitaId)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);
        }
    }
}
