using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProyectCRM.Swagger
{
    public class AuthFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Si el endpoint no tiene [Authorize], no hacer nada
            if (!context.ApiDescription.ActionDescriptor
                .EndpointMetadata.OfType<AuthorizeAttribute>().Any())
            {
                return;
            }

            // Si el endpoint tiene [AllowAnonymous], no aplicar seguridad
            if (context.ApiDescription.ActionDescriptor
                    .EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            // Aplicar esquema de seguridad Bearer
            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { } // Array vacío para JWT sin scopes específicos
                    }
                }
            };
        }
    }
}
