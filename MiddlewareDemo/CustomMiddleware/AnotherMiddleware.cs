using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareDemo.CustomMiddleware
{
    /// <summary>
    /// Custom middleware to demonstrate request handling before and after the next middleware.
    /// </summary>
    public class AnotherMiddleware
    {
        private readonly RequestDelegate _next;

        #region Constructor

        /// <summary>
        /// Initializes the middleware with the next request delegate.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        public AnotherMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Middleware Logic

        /// <summary>
        /// Writes messages before and after invoking the next middleware.
        /// </summary>
        /// <param name="httpContext">The HTTP context for the request.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Before AnotherMiddleware \n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("After AnotherMiddleware \n");
        }

        #endregion
    }

    /// <summary>
    /// Extension methods for registering the custom middleware.
    /// </summary>
    public static class AnotherMiddlewareExtensions
    {
        #region Extension Method

        /// <summary>
        /// Registers AnotherMiddleware in the application pipeline.
        /// </summary>
        /// <param name="builder">The application builder.</param>
        /// <returns>The updated application builder with middleware added.</returns>
        public static IApplicationBuilder UseAnotherMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnotherMiddleware>();
        }

        #endregion
    }
}
