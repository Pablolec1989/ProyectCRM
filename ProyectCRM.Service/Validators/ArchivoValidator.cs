using FluentValidation;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Validators
{
    public class ArchivoValidator : AbstractValidator<ArchivoUpdateCreateDTO>
    {
        public ArchivoValidator()
        {
            RuleFor(x => x.NombreArchivo)
                .NotEmpty().WithMessage("El nombre del archivo es obligatorio.")
                .MaximumLength(255).WithMessage("El nombre del archivo no puede exceder los 255 caracteres.");
        }
    }
}
