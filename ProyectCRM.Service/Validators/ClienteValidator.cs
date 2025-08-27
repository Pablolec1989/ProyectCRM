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
    public class ClienteValidator : AbstractValidator<ClienteRequestDTO>
    {
        public ClienteValidator()
        {
            RuleFor(c=> c.Nombre)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));
            
            RuleFor(c => c.Apellido)
                .NotEmpty().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));
            
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage(ValidationMessages.CampoObligatorio)
                .MaximumLength(100).WithMessage(ValidationMessages.MaxLength(50));
        }
    }
}
