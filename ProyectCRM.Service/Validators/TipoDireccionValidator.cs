using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class TipoDireccionValidator : AbstractValidator<TipoDireccionUpdateCreateDTO>
    {
        public TipoDireccionValidator()
        {
            RuleFor(td => td.Nombre).NotEmpty();
        }
    }
}
