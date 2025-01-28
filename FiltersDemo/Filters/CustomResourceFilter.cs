using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Custom resource filter to execute code before and after a resource is processed.
    /// </summary>
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        private readonly string _name;

        /// <summary>
        /// Initializes the filter with a name.
        /// </summary>
        /// <param name="name">The name associated with the filter.</param>
        public CustomResourceFilter(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Executes after the resource is processed.
        /// </summary>
        /// <param name="context">The context of the executed resource.</param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Resource Filter - After execution {_name}");
        }

        /// <summary>
        /// Executes before the resource is processed.
        /// </summary>
        /// <param name="context">The context of the resource being executed.</param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Resource Filter - Before execution {_name}");
        }
    }
}
