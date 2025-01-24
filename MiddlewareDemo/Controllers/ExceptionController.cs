using Microsoft.AspNetCore.Mvc;

namespace MiddlewareDemo.Controllers
{
    /// <summary>
    /// Handles exception-related endpoints.
    /// </summary>
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        #region Actions

        /// <summary>
        /// Simulates an error by throwing an exception.
        /// </summary>
        /// <returns>Throws an exception.</returns>
        /// <exception cref="Exception">Test exception thrown for error simulation.</exception>
        [HttpGet]
        [Route("error")]
        public IActionResult Get()
        {
            throw new Exception("Test Exception");
        }

        #endregion
    }
}
