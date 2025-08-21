using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class RubroValidator : AbstractValidator<RubroRequestDTO>
    {
        public RubroValidator()
        {
            RuleFor(r => r.Nombre)
                .NotEmpty().WithMessage("El rubro es obligatorio.")
                .MaximumLength(50).WithMessage("El campo nombre excede el limite de caracteres.");
        }
    }
}
