using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting.Server;
using MiddlewareDemo.CustomMiddleware;
using static System.Net.WebRequestMethods;

namespace MiddlewareDemo
{
    /// <summary>
    /// Configures and runs the web application.
    /// </summary>
    public class Program
    {
        #region Main Method

        /// <summary>
        /// Main entry point for configuring and starting the web application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add controllers 
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // register custom middleware as a service
            builder.Services.AddTransient<MyMiddleware>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            #region Middleware Flow

            // middleware flow
            /// if exception occurs , pipeline redirect to "/error"
            app.UseExceptionHandler("/error");
            app.Map("/error", (HttpContext context) =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                return Results.Problem(title: "An error occurred", detail: exception?.Message);
            });
            /// enforcing that browsers communicate with the server over HTTPS only
            app.UseHsts();
            /// Redirects HTTP requests to HTTPS
            app.UseHttpsRedirection();
            ///required to serve Static files
            app.UseStaticFiles();
            /// responsible for finding routes and invoking the corresponding action in a controller
            app.UseRouting();

            #endregion

            #region Custom Middlewares
            /*
            app.Use(async (HttpContext context, RequestDelegate next) =>
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
            */
            #endregion

            #region Swagger Setup (For Development)
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #endregion

            #region Run Application

            app.Run();

            #endregion
        }

        #endregion
    }
}
