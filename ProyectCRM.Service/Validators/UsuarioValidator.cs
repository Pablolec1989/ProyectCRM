using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioRequestDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nombre).NotEmpty();
            RuleFor(u => u.Apellido).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.RolId).NotEmpty();

        }
    }
}
