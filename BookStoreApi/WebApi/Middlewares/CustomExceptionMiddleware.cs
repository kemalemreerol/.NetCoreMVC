using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApi.Servcies;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext httpContext)
        { 
            var watch = Stopwatch.StartNew();
            try  
            {
              
              string message = "[Request]  HTTP " + httpContext.Request.Method + " - " + httpContext.Request.Path;
              _loggerService.Write(message);
              await _next.Invoke(httpContext);
              watch.Stop();
              message = "[Response] HTTP " + httpContext.Request.Method + " - " + httpContext.Request.Path + " responded " + httpContext.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms " ;
              _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(httpContext,ex,watch);
                
            }
            
 
        }

        private Task HandleException(HttpContext httpContext, Exception ex, Stopwatch watch)
        {

           httpContext.Response.ContentType = "application/json";
           httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;;

           string message = "[Error] HTTP " + httpContext.Request.Method + " - " + httpContext.Response.StatusCode + " Error Message " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms ";
           _loggerService.Write(message);

           var result = JsonConvert.SerializeObject(new {error = ex.Message}, Formatting.None);
           return httpContext.Response.WriteAsync(result);
        }
    }
}