using Microsoft.AspNetCore.Mvc;

namespace ActionMethod.Controllers
{
    /// <summary>
    /// Controller for example of different Action methods
    /// Provides endpoints to retrieve, add, check existence, and delete books.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public static List<string> books = new List<string> { "Book1", "Book2", "Book3" };

        #region Get Methods

        /// <summary>
        /// Retrieves all books in the collection.
        /// </summary>
        /// <returns>A list of book names.</returns>
        [HttpGet("GetAllBooks")]
        public IEnumerable<string> GetAllBooks()
        {
            return books;
        }

        /// <summary>
        /// Checks whether a specific book exists in the collection.
        /// </summary>
        /// <param name="bookName">The name of the book to check.</param>
        /// <returns>True if the book exists, otherwise false.</returns>
        [HttpGet("IsBookExist/{bookName}")]
        public bool IsBookExist(string bookName)
        {
            return books.Contains(bookName);
        }

        #endregion

        #region Post Methods

        /// <summary>
        /// Adds a new book to the collection.
        /// </summary>
        /// <param name="value">The name of the book to add.</param>
        [HttpPost("AddBook")]
        public void PostBook([FromBody] string value)
        {
            books.Add(value);
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// Deletes a book by its index in the collection.
        /// </summary>
        /// <param name="id">The index of the book to delete.</param>
        /// <returns>Returns a status message indicating the result of the operation.</returns>
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid id");
            }
            else if (id >= books.Count)
            {
                return NotFound("Id not exist");
            }

            books.RemoveAt(id);

            return Ok("Book deleted");
        }

        #endregion

        #region Redirect Methods

        /// <summary>
        /// Redirects to the Miracle Web download page.
        /// </summary>
        /// <returns>A redirect response to the Miracle Web page.</returns>
        [HttpGet("GotoMiracleWeb")]
        public IActionResult GotoMiracleWeb()
        {
            return Redirect("https://www.rkitsoftware.com/download-miracle");
        }

        #endregion
    }
}
