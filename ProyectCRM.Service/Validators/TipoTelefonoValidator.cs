using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class TipoTelefonoValidator : AbstractValidator<TipoTelefonoUpdateCreateDTO>
    {
        public TipoTelefonoValidator()
        {
            RuleFor(tt => tt.Nombre).NotEmpty();
        }

    }
}
