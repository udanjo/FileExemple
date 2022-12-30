using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace fileExemple.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsyn(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (System.Exception error)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if(!context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";
                    var response = new List<string> {"Ocorreu um erro!"};
                    var json = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(json);
                }

                var route = context.Request.Path.ToString().ToLower().Trim('/');
                var message = $"[ERROR] - Route: {route}";
                _logger.LogError(error, message);
            }
        }
    }
}