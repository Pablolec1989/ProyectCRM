using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class VisitaValidator : AbstractValidator<VisitaRequestDTO>
    {
        public VisitaValidator()
        {
            RuleFor(v => v.ClienteId).NotNull().NotEmpty();
            RuleFor(v => v.Observaciones).NotEmpty();
            RuleFor(v => v.DireccionId).NotEmpty();
        }
    }
}
