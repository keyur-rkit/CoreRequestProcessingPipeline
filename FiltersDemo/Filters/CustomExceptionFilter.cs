using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Exception (my) : {context.Exception}");
            // Create a response object with a generic error message and the exception details
            var response = new
            {
                Message = "An error occurred.",
                Error = context.Exception.Message
            };

            // Set the result to an ObjectResult with the response object and a 500 status code
            context.Result = new ObjectResult(response)
            {
                StatusCode = 500
            };
        }
    }
}
