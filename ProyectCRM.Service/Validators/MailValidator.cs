using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class MailValidator : AbstractValidator<MailRequestDTO>
    {
        public MailValidator()
        {
            RuleFor(m => m.ClienteId).NotNull();
            RuleFor(m => m.UsuarioId).NotNull();
            RuleFor(m => m.FechaMail).NotNull();
            RuleFor(m => m.AsuntoDeContactoId).NotNull();
            RuleFor(m => m.Detalle).NotEmpty()
                .WithMessage("El campo no puede estar vacio");

        }
    }
}
