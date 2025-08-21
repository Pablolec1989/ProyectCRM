using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class SeguimientoValidator : AbstractValidator<SeguimientoRequestDTO>
    {
        public SeguimientoValidator()
        {
            RuleFor(s => s.Titulo).NotEmpty();
            RuleFor(s => s.Detalle).NotEmpty();
            RuleFor(s => s.ClienteId).NotNull();
            RuleFor(s => s.UsuarioId).NotNull();
            RuleFor(s => s.FechaCreacion).NotNull();
        }
    }
}
