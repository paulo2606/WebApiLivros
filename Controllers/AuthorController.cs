﻿using Microsoft.AspNetCore.Http;
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
    }
}
