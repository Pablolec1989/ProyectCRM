using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class TelefonoClienteValidator : AbstractValidator<TelefonoClienteRequestDTO>
    {
        public TelefonoClienteValidator()
        {
            RuleFor(tc => tc.ClienteId).NotEmpty();
            RuleFor(tc => tc.Numero).NotEmpty();
        }
    }
}
