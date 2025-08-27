using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Validators.Utils
{
    public static class ValidationMessages
    {
        public const string CampoObligatorio = "El campo es requerido";

        public static string MinLength(int minLength) 
            => $"El campo debe tener al menos {minLength} caracteres.";
        public static string MaxLength(int maxLength)
            => $"El campo no puede exceder los {maxLength} caracteres.";

    }
}
