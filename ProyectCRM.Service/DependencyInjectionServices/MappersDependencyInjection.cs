using Microsoft.Extensions.DependencyInjection;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DependencyInjectionServices
{
    public static class MappersDependencyInjection
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddScoped<IAreaMapper, AreaMapper>();
            services.AddScoped<IAsuntoDeContactoMapper, AsuntoDeContactoMapper>();
            services.AddScoped<IClienteMapper, ClienteMapper>();
            services.AddScoped<ICondicionIvaMapper, CondicionIvaMapper>();
            services.AddScoped<IDireccionMapper, DireccionMapper>();
            services.AddScoped<IEmpresaMapper, EmpresaMapper>();
            services.AddScoped<ILlamadoMapper, LlamadoMapper>();
            services.AddScoped<IRolMapper, RolMapper>();
            services.AddScoped<IRubroMapper, RubroMapper>();
            services.AddScoped<ISeguimientoMapper, SeguimientoMapper>();
            services.AddScoped<ITelefonoClienteMapper, TelefonoClienteMapper>();
            services.AddScoped<ITipoDireccionMapper, TipoDireccionMapper>();
            services.AddScoped<ITipoTelefonoMapper, TipoTelefonoMapper>();
            services.AddScoped<IUsuarioMapper, UsuarioMapper>();
            services.AddScoped<IVisitaMapper, VisitaMapper>();
            services.AddScoped<IVisitaUsuarioMapper, VisitaUsuarioMapper>();
            services.AddScoped<IArchivoMapper, ArchivoMapper>();
            services.AddScoped<IMailMapper, MailMapper>();

            return services;
        }
    }
}
