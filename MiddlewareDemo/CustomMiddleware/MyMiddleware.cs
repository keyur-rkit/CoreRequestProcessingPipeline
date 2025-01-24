namespace MiddlewareDemo.CustomMiddleware
{
    /// <summary>
    /// Custom middleware that writes messages before and after processing the request.
    /// </summary>
    public class MyMiddleware : IMiddleware
    {
        #region Middleware Logic

        /// <summary>
        /// Handles the request by writing messages before and after the next middleware.
        /// </summary>
        /// <param name="context">The HTTP context for the current request.</param>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Before MyMiddleware \n");
            await next(context);
            await context.Response.WriteAsync("After MyMiddleware \n");
        }

        #endregion
    }

    /// <summary>
    /// Extension methods for adding MyMiddleware to the application's request pipeline.
    /// </summary>
    public static class MyMiddlewareExtension
    {
        #region Extension Method

        /// <summary>
        /// Adds MyMiddleware to the application's request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <returns>The updated IApplicationBuilder with MyMiddleware added.</returns>
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }

        #endregion
    }
}
