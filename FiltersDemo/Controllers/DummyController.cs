using FiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    /// <summary>
    /// dummy controller to test flow of Filters at contorller level
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [CustomActionFilters("Controller")]
    [CustomAuthorizationFilter("Controller")]
    [CustomResourceFilter("Controller")]
    [CustomResultFilter("Controller")]
    public class DummyController : ControllerBase
    {
        /// <summary>
        /// dummy method to test flow of filters at action level
        /// </summary>
        /// <returns>dummy Ok response</returns>
        [HttpGet("GetDummy")]
        [CustomActionFilters("Action")]
        [CustomAuthorizationFilter("Action")]
        [CustomResourceFilter("Action")]
        [CustomResultFilter("Action")]
        public IActionResult GetDummy()
        {
            return Ok("Hellow");
        }

        /// <summary>
        /// dummy method to test Exception filter
        /// </summary>
        /// <exception cref="Exception">blank exception</exception>
        [HttpGet("GetException")]
        public IActionResult GetException()
        {
            throw new Exception();
        }
    }
}
