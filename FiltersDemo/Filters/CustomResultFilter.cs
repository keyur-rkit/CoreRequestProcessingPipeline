using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        private readonly string _name;

        public CustomResultFilter(string name)
        {
            _name = name;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"Result Filter - After execution {_name}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"Result Filter - Before execution {_name}");
        }
    }
}
