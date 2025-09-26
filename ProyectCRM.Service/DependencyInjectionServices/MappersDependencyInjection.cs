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
            // Registrar los mappers en el contenedor DI (opcional)
            services.AddScoped<ArchivoMapper>();
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
            services.AddScoped<TelefonoMapper>();
            services.AddScoped<TipoDireccionMapper>();
            services.AddScoped<TipoTelefonoMapper>();
            services.AddScoped<UsuarioMapper>();
            services.AddScoped<VisitaMapper>();
            services.AddScoped<MailMapper>();

            // REGISTRO GLOBAL DE MAPPINGS
            RegisterAllMappings();

            return services;
        }

        private static void RegisterAllMappings()
        {
            new ArchivoMapper().RegisterMappings();
            new AreaMapper().RegisterMappings();
            new CondicionIvaMapper().RegisterMappings();
            new RubroMapper().RegisterMappings();
            new AsuntoDeContactoMapper().RegisterMappings();
            new RolMapper().RegisterMappings();
            new ClienteMapper().RegisterMappings();
            new DireccionMapper().RegisterMappings();
            new EmpresaMapper().RegisterMappings();
            new LlamadoMapper().RegisterMappings();
            new SeguimientoMapper().RegisterMappings();
            new TelefonoMapper().RegisterMappings();
            new TipoDireccionMapper().RegisterMappings();
            new TipoTelefonoMapper().RegisterMappings();
            new UsuarioMapper().RegisterMappings();
            new VisitaMapper().RegisterMappings();
            new MailMapper().RegisterMappings();
        }
    }
}
