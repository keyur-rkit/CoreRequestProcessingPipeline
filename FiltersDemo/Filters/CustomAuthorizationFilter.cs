using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomAuthorizationFilter : Attribute,IAuthorizationFilter
    {

        private readonly string _name;

        public CustomAuthorizationFilter(string name)
        {
            _name = name;
        }   

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine($"Authorization Filter - {_name}");

            bool isAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated ?? false;

            //if (!isAuthenticated)
            //{
            //    context.Result = new UnauthorizedResult();
            //}
        }
    }
}
