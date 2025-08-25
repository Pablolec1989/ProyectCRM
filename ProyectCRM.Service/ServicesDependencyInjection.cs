using Microsoft.Extensions.DependencyInjection;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IArchivoService, ArchivoService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IAsuntoDeContactoService, AsuntoDeContactoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICondicionIvaService, CondicionIvaService>();
            services.AddScoped<IDireccionService, DireccionService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<ILlamadoService, LlamadoService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IRubroService, RubroService>();
            services.AddScoped<ISeguimientoService, SeguimientoService>();
            services.AddScoped<ITelefonoClienteService, TelefonoClienteService>();
            services.AddScoped<ITipoDireccionService, TipoDireccionService>();
            services.AddScoped<ITipoTelefonoService, TipoTelefonoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVisitaService, VisitaService>();
            services.AddScoped<IVisitaUsuarioService, VisitaUsuarioService>();

            return services;
        }
    }
}
