using FluentValidation;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class AreaRequestValidator : AbstractValidator<AreaRequestDTO>
    {
        public AreaRequestValidator()
        {
            RuleFor(a => a.Nombre)
                .NotEmpty().WithMessage("El campo es obligatorio.")
                .MaximumLength(50).WithMessage("El campo nombre excede el limite de caracteres.");
        }
    }
}
