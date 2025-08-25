using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProyectCRM;
using ProyectCRM.Data;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Service.Mappers;
using ProyectCRM.Service.Services;
using ProyectCRM.Service.Utilities;
using ProyectCRM.Service.Validators;
using Scrutor;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); // Required for attribute routing and controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS Config
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

//Config y Registro de DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configuración de Almacenamiento de Archivos
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


//Fluent Validation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Configuración de servicios:
// Areas
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IAreaMapper, AreaMapper>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IValidator<AreaRequestDTO>, AreaRequestValidator>();

//AsuntoDeContacto
builder.Services.AddScoped<IAsuntoDeContactoRepository, AsuntoDeContactoRepository>();
builder.Services.AddScoped<IAsuntoDeContactoMapper, AsuntoDeContactoMapper>();
builder.Services.AddScoped<IAsuntoDeContactoService, AsuntoDeContactoService>();
builder.Services.AddScoped<IValidator<AsuntoDeContactoRequestDTO>, AsuntoDeContactoValidator>();

//Clientes
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteMapper, ClienteMapper>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IValidator<ClienteRequestDTO>, ClienteValidator>();

//CondicionIva
builder.Services.AddScoped<ICondicionIvaRepository, CondicionIvaRepository>();
builder.Services.AddScoped<ICondicionIvaMapper, CondicionIvaMapper>();
builder.Services.AddScoped<ICondicionIvaService, CondicionIvaService>();
builder.Services.AddScoped<IValidator<CondicionIvaRequestDTO>, CondicionIvaValidator>();

//Direcciones
builder.Services.AddScoped<IDireccionRepository, DireccionRepository>();
builder.Services.AddScoped<IDireccionMapper, DireccionMapper>();
builder.Services.AddScoped<IDireccionService, DireccionService>();
builder.Services.AddScoped<IValidator<DireccionRequestDTO>, DireccionValidator>();

//Empresas
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEmpresaMapper, EmpresaMapper>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IValidator<EmpresaRequestDTO>, EmpresaValidator>();

//Llamadas
builder.Services.AddScoped<ILlamadoRepository, LlamadoRepository>();
builder.Services.AddScoped<ILlamadoMapper, LlamadoMapper>();
builder.Services.AddScoped<ILlamadoService, LlamadoService>();
builder.Services.AddScoped<IValidator<LlamadoRequestDTO>, LlamadoValidator>();

//Mails
builder.Services.AddScoped<IMailRepository, MailRepository>();
builder.Services.AddScoped<IMailMapper, MailMapper>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IValidator<MailRequestDTO>, MailValidator>();

// Rubros
builder.Services.AddScoped<IRubroRepository, RubroRepository>();
builder.Services.AddScoped<IMapperBase<RubroDTO, RubroRequestDTO, Rubro>, RubroMapper>();
builder.Services.AddScoped<IRubroMapper, RubroMapper>();
builder.Services.AddScoped<IRubroService, RubroService>();
builder.Services.AddScoped<IValidator<RubroRequestDTO>, RubroValidator>();

//Roles
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolMapper, RolMapper>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IValidator<RolRequestDTO>, RolValidator>();

//Rubros
builder.Services.AddScoped<IRubroRepository, RubroRepository>();
builder.Services.AddScoped<IRubroMapper, RubroMapper>();
builder.Services.AddScoped<IRubroService, RubroService>();
builder.Services.AddScoped<IValidator<RubroRequestDTO>, RubroValidator>();

//Seguimientos
builder.Services.AddScoped<ISeguimientoRepository, SeguimientoRepository>();
builder.Services.AddScoped<ISeguimientoMapper, SeguimientoMapper>();
builder.Services.AddScoped<ISeguimientoService, SeguimientoService>();
builder.Services.AddScoped<IValidator<SeguimientoRequestDTO>, SeguimientoValidator>();

//TelefonoCliente
builder.Services.AddScoped<ITelefonoClienteRepository, TelefonoClienteRepository>();
builder.Services.AddScoped<ITelefonoClienteMapper, TelefonoClienteMapper>();
builder.Services.AddScoped<ITelefonoClienteService, TelefonoClienteService>();
builder.Services.AddScoped<IValidator<TelefonoClienteRequestDTO>, TelefonoClienteValidator>();

// Tipos de Direccion
builder.Services.AddScoped<ITipoDireccionRepository, TipoDireccionRepository>();
builder.Services.AddScoped<ITipoDireccionMapper, TipoDireccionMapper>();
builder.Services.AddScoped<ITipoDireccionService, TipoDireccionService>();
builder.Services.AddScoped<IValidator<TipoDireccionRequestDTO>, TipoDireccionValidator>();

//TiposTelefono
builder.Services.AddScoped<ITipoTelefonoRepository, TipoTelefonoRepository>();
builder.Services.AddScoped<ITipoTelefonoMapper, TipoTelefonoMapper>();
builder.Services.AddScoped<ITipoTelefonoService, TipoTelefonoService>();
builder.Services.AddScoped<IValidator<TipoTelefonoRequestDTO>, TipoTelefonoValidator>();

//Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioMapper, UsuarioMapper>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IValidator<UsuarioRequestDTO>, UsuarioValidator>();

//Visitas
builder.Services.AddScoped<IVisitaRepository, VisitaRepository>();
builder.Services.AddScoped<IVisitaMapper, VisitaMapper>();
builder.Services.AddScoped<IVisitaService, VisitaService>();
builder.Services.AddScoped<IValidator<VisitaRequestDTO>, VisitaValidator>();

//Archivo
builder.Services.AddScoped<IArchivoRepository, VisitaArchivoRepository>();
builder.Services.AddScoped<IArchivoMapper, ArchivoMapper>();
builder.Services.AddScoped<IArchivoService, ArchivoService>();
builder.Services.AddScoped<IValidator<ArchivoRequestDTO>, ArchivoRequestValidator>();

// VisitaUsuario
builder.Services.AddScoped<IVisitaUsuarioRepository, VisitaUsuarioRepository>();
builder.Services.AddScoped<IVisitaUsuarioMapper, VisitaUsuarioMapper>();
builder.Services.AddScoped<IVisitaUsuarioService, VisitaUsuarioService>();
builder.Services.AddScoped<IValidator<VisitaUsuarioRequestDTO>, VisitaUsuarioValidator>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature is not null)
        {
            Console.WriteLine($"Error: {contextFeature.Error}");
            await context.Response.WriteAsJsonAsync(
                new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error",
                    MoreInfo = contextFeature.Error.Message,
                });
        };
    });
});

app.Run();

