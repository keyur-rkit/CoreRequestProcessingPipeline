namespace RoutingDemo
{
    /// <summary>
    /// Entry point for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Configures and starts the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Add Swagger services.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // optional parameter
                endpoints.Map("/book/{id}/{name?}", async (context) =>
                {
                    var bookId = Convert.ToInt32(context.Request.RouteValues["id"]);
                    var bookName = Convert.ToString(context.Request.RouteValues["name"]);
                    await context.Response.WriteAsync($"Book id : {bookId}\nBook name : {bookName}");
                });

                // default parameter
                endpoints.Map("/author/{name=keyur}", async (context) =>
                {
                    var name = Convert.ToString(context.Request.RouteValues["name"]);
                    await context.Response.WriteAsync($"Name : {name}");
                });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controlle}/{action}/{id?}");
            });

            // default response
            app.Run(async context =>
            {
                await context.Response.WriteAsync("default");
            });

            app.Run();
        }
    }
}
