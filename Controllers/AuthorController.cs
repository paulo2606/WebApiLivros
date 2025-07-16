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

        [HttpGet("ListAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> ListAuthor()
        {
            var response = await _authorInterface.ListAuthor();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
