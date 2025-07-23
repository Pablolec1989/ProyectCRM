using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectCRM.Data;
using ProyectCRM.Mapper;
using ProyectCRM.Mapper.AreaDTOs;
using ProyectCRM.Models;
using ProyectCRM.Service;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurar IConfiguration para acceder a los archivos de configuración

//Config y Registro de DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configuración de servicios personalizados - dependencias
// -- Areas -- 
builder.Services.AddScoped<IRepository<Area>, AreaRepository>();
builder.Services.AddScoped<IMapper<AreaDTO, AreaCreateUpdateDTO, Area>, AreaMapper>();
builder.Services.AddScoped<IService<AreaCreateUpdateDTO, AreaDTO>, AreaService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

