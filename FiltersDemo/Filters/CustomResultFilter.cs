using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Custom result filter to execute code before and after a result is processed.
    /// </summary>
    public class CustomResultFilter : Attribute, IResultFilter
    {
        private readonly string _name;

        /// <summary>
        /// Initializes the filter with a name.
        /// </summary>
        /// <param name="name">The name associated with the filter.</param>
        public CustomResultFilter(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Executes after the result is processed.
        /// </summary>
        /// <param name="context">The context of the executed result.</param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"Result Filter - After execution {_name}");
        }

        /// <summary>
        /// Executes before the result is processed.
        /// </summary>
        /// <param name="context">The context of the result being executed.</param>
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"Result Filter - Before execution {_name}");
        }
    }
}
