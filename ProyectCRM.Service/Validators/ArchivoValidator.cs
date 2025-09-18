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
    public class ArchivoValidator : AbstractValidator<ArchivoRequestDTO>
    {
        public ArchivoValidator()
        {
            RuleFor(a => a.NombreArchivo)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(a => a.RutaArchivo)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);

            RuleFor(a => a.VisitaId)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio);
        }
    }
}
