using Middleware.CustomMiddleware;

namespace Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // register custom middleware as a service
            builder.Services.AddTransient<MyMiddleware>();

            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");

            // middleware flow

            //app.UseExceptionHandler();
            //app.UseHsts();
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();
            //app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseSession();

            app.Use( async (HttpContext context,RequestDelegate next) =>
            {
                await context.Response.WriteAsync("Before 1 Middlerware \n");
                await next(context);
                await context.Response.WriteAsync("After 1 Middlerware \n");
            });


            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("Before 2 Middlerware \n");
                await next(context);
                await context.Response.WriteAsync("After 2 Middlerware \n");
            });

            // using custom middleware through service  
            app.UseMiddleware<MyMiddleware>();

            // using custom middleware through extension
            app.MyMiddleware();

            // using another middleware with built-in format
            app.UseAnotherMiddleware();

            // conditional middleware (use "?keyur" in url)
            app.UseWhen(context => context.Request.Query.ContainsKey("keyur"),
                app =>
                {
                    app.Use(async (context, next) =>
                    {
                        await context.Response.WriteAsync("Before conditional Middlerware \n");
                        await next(context);
                        await context.Response.WriteAsync("After conditional Middlerware \n");
                    });
                });

            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync("3 Middlerware \n");
            });

            app.Run();
        }
    }
}