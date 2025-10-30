using Microsoft.EntityFrameworkCore;

namespace ProyectCRM.Utils
{
    public static class HttpContextExtension
    {
        public static void InsertarParametrosPaginacionEnCabecera<TDTO>(this HttpContext httpContext, int totalRegistros)
        {
            if (httpContext is null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            httpContext.Response.Headers.Append("totalRecords", totalRegistros.ToString());
        }
    }
}
