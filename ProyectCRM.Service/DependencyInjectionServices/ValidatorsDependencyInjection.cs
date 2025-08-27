using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DependencyInjectionServices
{
    public static class ValidatorsDependencyInjection
    {
        public static IServiceCollection AddValidators (this IServiceCollection services)
        {

            services.AddScoped<IValidator<AreaRequestDTO>, AreaValidator>();
            services.AddScoped<IValidator<AsuntoDeContactoRequestDTO>, AsuntoDeContactoValidator>();
            services.AddScoped<IValidator<ClienteRequestDTO>, ClienteValidator>();
            services.AddScoped<IValidator<CondicionIvaRequestDTO>, CondicionIvaValidator>();
            services.AddScoped<IValidator<DireccionRequestDTO>, DireccionValidator>();
            services.AddScoped<IValidator<EmpresaRequestDTO>, EmpresaValidator>();
            services.AddScoped<IValidator<LlamadaRequestDTO>, LlamadoValidator>();
            services.AddScoped<IValidator<RolRequestDTO>, RolValidator>();
            services.AddScoped<IValidator<RubroRequestDTO>, RubroValidator>();
            services.AddScoped<IValidator<SeguimientoRequestDTO>, SeguimientoValidator>();
            services.AddScoped<IValidator<TelefonoClienteRequestDTO>, TelefonoClienteValidator>();
            services.AddScoped<IValidator<TipoDireccionRequestDTO>, TipoDireccionValidator>();
            services.AddScoped<IValidator<TipoTelefonoRequestDTO>, TipoTelefonoValidator>();
            services.AddScoped<IValidator<UsuarioRequestDTO>, UsuarioValidator>();
            services.AddScoped<IValidator<VisitaRequestDTO>, VisitaValidator>();
            services.AddScoped<IValidator<VisitaUsuarioRequestDTO>, VisitaUsuarioValidator>();
            services.AddScoped<IValidator<ArchivoRequestDTO>, ArchivoValidator>();
            services.AddScoped<IValidator<MailRequestDTO>, MailValidator>();

            return services;
        }
    }
}
