using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomActionFilters : Attribute, IActionFilter, IOrderedFilter
    {
        private readonly string _name;

        public int Order { get; set; }

        public CustomActionFilters(string name, int order = 0)
        {
            _name = name;
            Order = order;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action Filter - After execution {_name} {Order}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action Filter - Before execution {_name} {Order}");
        }
    }
}
