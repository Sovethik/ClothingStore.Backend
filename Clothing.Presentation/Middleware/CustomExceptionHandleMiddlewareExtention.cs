namespace Clothing.Presentation.Middleware
{
    public static class CustomExceptionHandleMiddlewareExtention
    {

        public static IApplicationBuilder UseCustomHandleExceptions(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExeptionHandleMiddleware>();
        }
    }
}
