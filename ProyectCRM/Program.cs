using Microsoft.EntityFrameworkCore;
using ProyectCRM;
using ProyectCRM.Controllers;
using ProyectCRM.Data;
using ProyectCRM.Data.Repositories;
using ProyectCRM.Models;
using ProyectCRM.Service;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.Mappers;
using ProyectCRM.Service.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); // Required for attribute routing and controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Config y Registro de DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configuración de servicios
builder.Services.AddScoped<IServiceBase<AreaDTO, Area>, AreaService>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
// Configuración de mapeo
builder.Services.AddScoped<IAreaMapper, AreaMapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); // Add this if you use [Authorize] attributes

app.MapControllers(); // Ensure this is present to map controller endpoints

app.Run();

