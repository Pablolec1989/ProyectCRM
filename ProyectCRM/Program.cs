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
using ProyectCRM.Service.DTOs.DireccionDTO;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Service.Mappers;
using ProyectCRM.Service.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); // Required for attribute routing and controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configuración de servicios:
// Areas
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IMapperBase<AreaDTO, AreaUpdateCreateDTO, Area>, AreaMapper>();
builder.Services.AddScoped<IAreaMapper, AreaMapper>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IValidator<Area>, AreaValidator>();

// Rubros
builder.Services.AddScoped<IRubroRepository, RubroRepository>();
builder.Services.AddScoped<IMapperBase<RubroDTO, RubroUpdateCreateDTO, Rubro>, RubroMapper>();
builder.Services.AddScoped<IRubroMapper, RubroMapper>();
builder.Services.AddScoped<IRubroService, RubroService>();

//Direcciones
builder.Services.AddScoped<IDireccionRepository, DireccionRepository>();
builder.Services.AddScoped<IMapperBase<DireccionDTO, DireccionCreateUpdateDTO, Direccion>, DireccionMapper>();
builder.Services.AddScoped<IDireccionMapper, DireccionMapper>();
builder.Services.AddScoped<IDireccionService, DireccionService>();

// Tipos de Direccion
builder.Services.AddScoped<ITipoDireccionRepository, TipoDireccionRepository>();
builder.Services.AddScoped<IMapperBase<TipoDireccionDTO, TipoDireccionUpdateCreateDTO, TipoDireccion>, TipoDireccionMapper>();
builder.Services.AddScoped<ITipoDireccionMapper, TipoDireccionMapper>();
builder.Services.AddScoped<ITipoDireccionService, TipoDireccionService>();

//TiposTelefono
builder.Services.AddScoped<ITipoTelefonoRepository, TipoTelefonoRepository>();
builder.Services.AddScoped<IMapperBase<TipoTelefonoDTO, TipoTelefonoUpdateCreateDTO, TipoTelefono>, TipoTelefonoMapper>();
builder.Services.AddScoped<ITipoTelefonoMapper, TipoTelefonoMapper>();
builder.Services.AddScoped<ITipoTelefonoService, TipoTelefonoService>();

//AsuntoDeContacto
builder.Services.AddScoped<IAsuntoDeContactoRepository, AsuntoDeContactoRepository>();
builder.Services.AddScoped<IMapperBase<AsuntoDeContactoDTO, AsuntoDeContactoUpdateCreateDTO, AsuntoDeContactoDTO>, AsuntoDeContactoMapper>();
builder.Services.AddScoped<IAsuntoDeContactoMapper, AsuntoDeContactoMapper>();
builder.Services.AddScoped<IAsuntoDeContactoService, AsuntoDeContactoService>();

//CondicionIva
builder.Services.AddScoped<ICondicionIvaRepository, CondicionIvaRepository>();
builder.Services.AddScoped<IMapperBase<CondicionIvaDTO, CondicionIvaUpdateCreateDTO, CondicionIva>, CondicionIvaMapper>();
builder.Services.AddScoped<ICondicionIvaMapper, CondicionIvaMapper>();
builder.Services.AddScoped<ICondicionIvaService, CondicionIvaService>();

//Roles
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IMapperBase<RolDTO, RolUpdateCreateDTO, Rol>, RolMapper>();
builder.Services.AddScoped<IRolMapper, RolMapper>();
builder.Services.AddScoped<IRolService, RolService>();


//Fluent Validation
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
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

