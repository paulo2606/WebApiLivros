using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLivros.Model;
using WebApiLivros.Services;

namespace WebApiLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _authorInterface;
        public AuthorController(IAuthor authorInterface)
        {
            _authorInterface = authorInterface;
        }

        [HttpGet("ListBooks")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListBooks()
        {
            var response = await _authorInterface.ListBooks();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetAuthorById/{idAuthor}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int idAuthor)
        {
            var response = await _authorInterface.GetAuthorById(idAuthor);
            if (response.Status)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("GetAuthorByName/{nameAuthor}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByName(string nameAuthor)
        {
            var response = await _authorInterface.GetAuthorByName(nameAuthor);
            if (response.Status)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("GetBookByName/{title}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookByName(string title)
        {
            var response = await _authorInterface.GetBookByName(title);
            if (response.Status)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateAuthor([FromBody] BookModel newBook)
        {
            if (newBook == null)
            {
                return BadRequest("Author data is null.");
            }
            var response = await _authorInterface.CreateBook(newBook);
            if (response.Status)
            {
                return CreatedAtAction(nameof(GetAuthorById), new { idAuthor = response.Data.FirstOrDefault()?.Id }, response);
            }
            return BadRequest(response);
        }
    }
}
