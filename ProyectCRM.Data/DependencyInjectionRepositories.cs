using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectCRM.Models.Data.Interfaces;
using ProyectCRM.Models.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Data
{
    public static class DependencyInjectionRepositories
    {
        public static IServiceCollection AddInfrastructure (
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IArchivoRepository, ArchivoRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IAsuntoDeContactoRepository, AsuntoDeContactoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICondicionIvaRepository, CondicionIvaRepository>();
            services.AddScoped<IDireccionRepository, DireccionRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<ILlamadoRepository, LlamadoRepository>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IRubroRepository, RubroRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IRubroRepository, RubroRepository>();
            services.AddScoped<ISeguimientoRepository, SeguimientoRepository>();
            services.AddScoped<ITelefonoRepository, TelefonoRepository>();
            services.AddScoped<ITipoDireccionRepository, TipoDireccionRepository>();
            services.AddScoped<ITipoTelefonoRepository, TipoTelefonoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVisitaRepository, VisitaRepository>();
            services.AddScoped<IVisitaUsuarioRepository, VisitaUsuarioRepository>();

            return services;
        }
    }
}
