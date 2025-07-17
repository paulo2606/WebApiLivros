using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLivros.Model;
using WebApiLivros.Services;

namespace WebApiLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookInterface;
        public BookController(IBook bookInterface)
        {
            _bookInterface = bookInterface;
        }

        [HttpGet("ListBooks")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListBooks()
        {
            var response = await _bookInterface.ListBooks();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetBookByName/{title}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookByName(string title)
        {
            var response = await _bookInterface.GetBookByName(title);
            if (response.Status)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(BookModel newBook)
        {
            if (newBook == null)
            {
                return BadRequest("Author data is null.");
            }
            var response = await _bookInterface.CreateBook(newBook);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("DeleteBook/{idBook}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> DeleteBookById(int idBook)
        {
            var response = await _bookInterface.DeleteBook(idBook);
            if (response.Status)
            {
                return Ok(response);
            }
            return NotFound("Book value is null.");
        }



    }
}
