using Microsoft.EntityFrameworkCore;
using ProyectCRM;
using ProyectCRM.Data;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.DTOs.RubroDTOs;
using ProyectCRM.Service.Interfaces;
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

// Configuración de servicios
// Areas
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IMapperBase<AreaDTO, AreaCreateDTO, Area>, MapperBase<AreaDTO, Area, AreaCreateDTO>>();
builder.Services.AddScoped<IServiceBase<AreaDTO, AreaCreateDTO, Area>, AreaService>();

// Rubros
builder.Services.AddScoped<IRubroRepository, RubroRepository>();
builder.Services.AddScoped<IMapperBase<RubroDTO, RubroCreateDTO, Rubro>, MapperBase<RubroDTO, Rubro, RubroCreateDTO>>();
builder.Services.AddScoped<IRubroService, RubroService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization(); // Add this if you use [Authorize] attributes

app.MapControllers(); // Ensure this is present to map controller endpoints

app.Run();

