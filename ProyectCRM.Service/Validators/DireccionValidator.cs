using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class DireccionValidator : AbstractValidator<DireccionUpdateCreateDTO>
    {
        public DireccionValidator()
        {
            RuleFor(d => d.CodigoPostal).MaximumLength(20);
            RuleFor(d => d.Calle).MaximumLength(150);
            RuleFor(d => d.Ciudad).MaximumLength(150);
            RuleFor(d => d.Provincia).MaximumLength(100);
        }
    }
}
