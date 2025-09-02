using FluentValidation;
using System.Net;
using System.Text.Json;
using Clothing.Application.Exceptions;

namespace Clothing.Presentation.Middleware
{
    public class CustomExeptionHandleMiddleware
    {
        private readonly RequestDelegate _next;


        public CustomExeptionHandleMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, ex);
            }
        }


        private Task HandlerExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;


            switch(ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Message);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(notFoundException.Message);
                    break;
            }

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            if (result == string.Empty)
                result = JsonSerializer.Serialize(new { error = ex.Message });

            return context.Response.WriteAsync(result);
        }


    }
}
