using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProyectCRM;
using ProyectCRM.Data;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Data.Repositories;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service;
using ProyectCRM.Service.DependencyInjectionServices;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Service.Mappers;
using ProyectCRM.Service.Services;
using ProyectCRM.Service.Utilities;
using ProyectCRM.Service.Validators;
using Scrutor;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddMappers();
builder.Services.AddValidators();



// With this line:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS Config
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configuración de Almacenamiento de Archivos
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Fluent Validation
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

