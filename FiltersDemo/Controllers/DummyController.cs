using FiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomActionFilters("Controller")]
    [CustomAuthorizationFilter("Controller")]
    [CustomResourceFilter("Controller")]
    [CustomResultFilter("Controller")]

    public class DummyController : ControllerBase
    {
        [HttpGet("GetDummy")]
        [CustomActionFilters("Action")]
        [CustomAuthorizationFilter("Action")]
        [CustomResourceFilter("Action")]
        [CustomResultFilter("Action")]
        public IActionResult GetDummy()
        {
            return Ok("Hellow");
        }

        [HttpGet("GetException")]
        public IActionResult GetException()
        {
            throw new Exception();
        }
    }
}
