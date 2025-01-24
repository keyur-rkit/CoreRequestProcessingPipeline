namespace Middleware.CustomMiddleware
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Before MyMiddleware \n");
            await next(context);
            await context.Response.WriteAsync("After MyMiddleware \n");
        }
    }

    public static class MyMiddlewareExtension
    {
        public static IApplicationBuilder MyMiddleware (this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}
