using FiltersDemo.Filters;

namespace FiltersDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new CustomActionFilters("Global",1));
                options.Filters.Add(new CustomAuthorizationFilter("Global"));
                options.Filters.Add(new CustomResourceFilter("Global"));
                options.Filters.Add(new CustomResultFilter("Global"));
                options.Filters.Add(new CustomExceptionFilter());
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}