using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Controller for handling requests related to values.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Retrieves all values.
        /// </summary>
        /// <returns>A list of values.</returns>
        // GET: api/<ValuesController>
        [HttpGet("GelValues")]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("api/ValuesController/GetAll called");
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Retrieves a specific value by ID.
        /// </summary>
        /// <param name="id">The ID of the value to retrieve.</param>
        /// <returns>A value.</returns>
        // GET api/<ValuesController>/5
        [HttpGet("{id:int:range(18,100)}")]
        public string Get(int id)
        {
            Console.WriteLine("api/ValuesController/GetById called");
            return "value1";
        }

        /// <summary>
        /// Creates a new value.
        /// </summary>
        // POST api/<ValuesController>
        [HttpPost("{value:alpha:minlength(4)}")]
        public void Post()
        {
            Console.WriteLine("api/ValuesController/Post called");
        }

        /// <summary>
        /// Updates an existing value.
        /// </summary>
        /// <param name="id">The ID of the value to update.</param>
        /// <param name="value">The new value.</param>
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine("api/ValuesController/Put called");
        }

        /// <summary>
        /// Deletes a specific value by ID.
        /// </summary>
        /// <param name="id">The ID of the value to delete.</param>
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("api/ValuesController/Delete called");
        }
    }
}
