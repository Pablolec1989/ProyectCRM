using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class LlamadoValidator : AbstractValidator<LlamadoRequestDTO>
    {
        public LlamadoValidator()
        {
            RuleFor(l => l.ClienteId).NotNull();
            RuleFor(l => l.UsuarioId).NotNull();
            RuleFor(l => l.AsuntoDeContactoId).NotNull();
            RuleFor(l => l.Detalle).NotNull();
            RuleFor(l => l.FechaLlamado).NotNull();

        }
    }
}
