using FluentValidation;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteUpdateCreateDTO>
    {
        public ClienteValidator()
        {
            RuleFor(c=> c.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede tener más de 50 caracteres.");
            RuleFor(c => c.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede tener más de 50 caracteres.");
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("El email no es válido.")
                .MaximumLength(100).WithMessage("El email no puede tener más de 100 caracteres.");
        }
    }
}
