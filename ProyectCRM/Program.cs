using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProyectCRM.Converters;
using ProyectCRM.Models.Data;
using ProyectCRM.Models.Service.DependencyInjectionServices;
using ProyectCRM.Models.Service.Mappers;
using ProyectCRM.Service.Utils;
using ProyectCRM.Swagger;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

//Cache config
builder.Services.AddOutputCache(options =>
{
    options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(20);
});

builder.Services.AddMapster();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddValidators();
builder.Services.AddScoped<ICacheCleaner, CacheCleaner>();

builder.Services.AddControllers().AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new DateTimeJsonCoverter());
    });

MappersDependencyInjection.AddMappers(builder.Services);


//CORS Config
var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");

builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(corsOptions =>
    {
        corsOptions.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(origenesPermitidos)
                    .WithExposedHeaders("cantidadTotalRegistros");
    });
});

//Service JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["KeyJwt"]!)),
            ClockSkew = TimeSpan.Zero,
            NameClaimType = ClaimTypes.Name,
            RoleClaimType = ClaimTypes.Role,
        };
    });


//Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

builder.Services.AddEndpointsApiExplorer();

//Swagger JWT Config
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    options.OperationFilter<AuthFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseOutputCache();
app.UseAuthentication();
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

