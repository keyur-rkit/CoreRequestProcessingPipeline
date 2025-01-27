using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        private readonly string _name;

        public CustomResourceFilter(string name)
        {
            _name = name;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Resource Filter - After execution {_name}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Resource Filter - Before execution {_name}");
        }
    }
}
