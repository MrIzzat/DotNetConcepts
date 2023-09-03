namespace Middleware.MiddleWareServices
{
    public class CustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
             await context.Response.WriteAsync("Custom Hell yeah");
        }
    }

    public static class ClassWithNoImplementationMiddlewareExtensions
    {
        public static IApplicationBuilder UseClassWithNoImplementationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleWare>();
        }
    }
}
