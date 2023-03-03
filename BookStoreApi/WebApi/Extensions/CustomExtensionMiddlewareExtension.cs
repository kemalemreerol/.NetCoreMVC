using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using WebApi.Middlewares;

namespace WebApi.Extensions
{
    static public class CustomExtensionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}