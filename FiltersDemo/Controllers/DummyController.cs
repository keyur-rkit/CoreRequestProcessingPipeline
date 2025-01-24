using FiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomActionFilters("Controller")]

    public class DummyController : ControllerBase
    {
        [HttpGet]
        [CustomActionFilters("Action")]
        public IActionResult Get()
        {
            return Ok("Hellow");
        }
    }
}
