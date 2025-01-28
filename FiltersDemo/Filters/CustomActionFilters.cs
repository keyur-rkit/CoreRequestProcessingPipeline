using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Custom action filter to execute code before and after an action method.
    /// </summary>
    public class CustomActionFilters : Attribute, IActionFilter, IOrderedFilter
    {
        private readonly string _name;

        /// <summary>
        /// Gets or sets the order of execution for the filter.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Initializes a new instance of the filter.
        /// </summary>
        /// <param name="name">Name associated with the filter.</param>
        /// <param name="order">Order of execution (default is 0).</param>
        public CustomActionFilters(string name, int order = 0)
        {
            _name = name;
            Order = order;
        }

        #region IActionFilter Methods

        /// <summary>
        /// Executes after the action method has run.
        /// </summary>
        /// <param name="context">The context of the executed action.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action Filter - After execution {_name} {Order}");
        }

        /// <summary>
        /// Executes before the action method runs.
        /// </summary>
        /// <param name="context">The context of the action being executed.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action Filter - Before execution {_name} {Order}");
        }

        #endregion
    }
}
