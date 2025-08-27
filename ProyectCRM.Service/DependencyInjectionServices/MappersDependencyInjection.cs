using Microsoft.Extensions.DependencyInjection;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DependencyInjectionServices
{
    public static class MappersDependencyInjection
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddScoped<AreaMapper>();
            services.AddScoped<CondicionIvaMapper>();
            services.AddScoped<RubroMapper>();
            services.AddScoped<AsuntoDeContactoMapper>();
            services.AddScoped<RolMapper>();
            services.AddScoped<ClienteMapper>();
            services.AddScoped<DireccionMapper>();
            services.AddScoped<EmpresaMapper>();
            services.AddScoped<LlamadoMapper>();
            services.AddScoped<SeguimientoMapper>();
            services.AddScoped<TelefonoClienteMapper>();
            services.AddScoped<TipoDireccionMapper>();
            services.AddScoped<TipoTelefonoMapper>();
            services.AddScoped<UsuarioMapper>();
            services.AddScoped<VisitaMapper>();
            services.AddScoped<VisitaUsuarioMapper>();
            services.AddScoped<ArchivoMapper>();
            services.AddScoped<MailMapper>();

            return services;
        }
    }
}
